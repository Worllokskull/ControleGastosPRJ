import { useEffect, useState } from 'react';

type PessoaResumo = {
  id: string;
  nome: string;
};

type PessoaDetalhada = {
  id: string;
  nome: string;
  idade: number;
  transacoes: Array<{ id: string; descricao: string }>;
  totalGasto: number;
};

type FormPessoa = {
  nome: string;
  idade: number;
};

type FormTransacao = {
  descricao: string;
  valor: number;
};

const API_URL = 'http://localhost:5229/api';

function App() {
  const [pessoas, setPessoas] = useState<PessoaResumo[]>([]);
  const [pessoaSelecionada, setPessoaSelecionada] = useState<PessoaDetalhada | null>(null);
  const [formPessoa, setFormPessoa] = useState<FormPessoa>({ nome: '', idade: 0 });
  const [formTransacao, setFormTransacao] = useState<FormTransacao>({ descricao: '', valor: 0 });
  const [loading, setLoading] = useState(false);
  const [message, setMessage] = useState('');

  const carregarPessoas = async () => {
    setLoading(true);
    try {
      const response = await fetch(`${API_URL}/Pessoas`);
      if (!response.ok) throw new Error('Erro ao buscar pessoas');
      const data = await response.json();
      setPessoas(data.pessoas ?? []);
    } catch (error) {
      setMessage((error as Error).message);
    } finally {
      setLoading(false);
    }
  };

  const selecionarPessoa = async (id: string) => {
    try {
      const response = await fetch(`${API_URL}/Pessoas/${id}`);
      if (!response.ok) throw new Error('Erro ao buscar detalhes da pessoa');
      const data = await response.json();
      setPessoaSelecionada(data);
    } catch (error) {
      setMessage((error as Error).message);
    }
  };

  const criarPessoa = async (event: React.FormEvent) => {
    event.preventDefault();
    try {
      const response = await fetch(`${API_URL}/Pessoas`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(formPessoa)
      });
      if (!response.ok) throw new Error('Erro ao criar pessoa');
      setFormPessoa({ nome: '', idade: 0 });
      setMessage('Pessoa criada com sucesso');
      await carregarPessoas();
    } catch (error) {
      setMessage((error as Error).message);
    }
  };

  const criarTransacao = async (event: React.FormEvent) => {
    event.preventDefault();
    if (!pessoaSelecionada) return;
    try {
      const response = await fetch(`${API_URL}/Transacao/${pessoaSelecionada.id}`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(formTransacao)
      });
      if (!response.ok) throw new Error('Erro ao criar transação');
      setFormTransacao({ descricao: '', valor: 0 });
      await selecionarPessoa(pessoaSelecionada.id);
      setMessage('Transação criada com sucesso');
    } catch (error) {
      setMessage((error as Error).message);
    }
  };

  const excluirPessoa = async (id: string) => {
    try {
      const response = await fetch(`${API_URL}/Pessoas/${id}`, { method: 'DELETE' });
      if (!response.ok) throw new Error('Erro ao excluir pessoa');
      setPessoaSelecionada(null);
      await carregarPessoas();
      setMessage('Pessoa excluída com sucesso');
    } catch (error) {
      setMessage((error as Error).message);
    }
  };

  const excluirTransacao = async (id: string) => {
    if (!pessoaSelecionada) return;
    try {
      const response = await fetch(`${API_URL}/Transacao/${id}`, { method: 'DELETE' });
      if (!response.ok) throw new Error('Erro ao excluir transação');
      await selecionarPessoa(pessoaSelecionada.id);
      setMessage('Transação excluída com sucesso');
    } catch (error) {
      setMessage((error as Error).message);
    }
  };

  useEffect(() => {
    carregarPessoas();
  }, []);

  return (
    <div className="app-shell">
      <header>
        <h1>Controle de Gastos</h1>
        <p>Gerencie pessoas e transações com a API local.</p>
      </header>

      {message ? <div className="message">{message}</div> : null}

      <main className="grid">
        <section className="card">
          <h2>Nova pessoa</h2>
          <form onSubmit={criarPessoa} className="form">
            <input
              placeholder="Nome"
              value={formPessoa.nome}
              onChange={(e) => setFormPessoa({ ...formPessoa, nome: e.target.value })}
            />
            <input
              type="number"
              placeholder="Idade"
              value={formPessoa.idade}
              onChange={(e) => setFormPessoa({ ...formPessoa, idade: Number(e.target.value) })}
            />
            <button type="submit">Criar pessoa</button>
          </form>
        </section>

        <section className="card">
          <h2>Pessoas</h2>
          {loading ? <p>Carregando...</p> : null}
          <ul>
            {pessoas.map((pessoa) => (
              <li key={pessoa.id}>
                <span>{pessoa.nome}</span>
                <div>
                  <button onClick={() => selecionarPessoa(pessoa.id)}>Detalhes</button>
                  <button onClick={() => excluirPessoa(pessoa.id)} className="danger">Excluir</button>
                </div>
              </li>
            ))}
          </ul>
        </section>

        <section className="card">
          <h2>Detalhes da pessoa</h2>
          {pessoaSelecionada ? (
            <>
              <p><strong>Nome:</strong> {pessoaSelecionada.nome}</p>
              <p><strong>Idade:</strong> {pessoaSelecionada.idade}</p>
              <p><strong>Total gasto:</strong> R$ {pessoaSelecionada.totalGasto.toFixed(2)}</p>
              <h3>Transações</h3>
              <ul>
                {pessoaSelecionada.transacoes.map((transacao) => (
                  <li key={transacao.id}>
                    <span>{transacao.descricao}</span>
                    <button onClick={() => excluirTransacao(transacao.id)} className="danger">Excluir</button>
                  </li>
                ))}
              </ul>

              <form onSubmit={criarTransacao} className="form">
                <input
                  placeholder="Descrição"
                  value={formTransacao.descricao}
                  onChange={(e) => setFormTransacao({ ...formTransacao, descricao: e.target.value })}
                />
                <input
                  type="number"
                  step="0.01"
                  placeholder="Valor"
                  value={formTransacao.valor}
                  onChange={(e) => setFormTransacao({ ...formTransacao, valor: Number(e.target.value) })}
                />
                <button type="submit">Adicionar transação</button>
              </form>
            </>
          ) : (
            <p>Selecione uma pessoa.</p>
          )}
        </section>
      </main>
    </div>
  );
}

export default App;
