using ControleGastos.API.Infraestrutura;
using ControleGastos.Communication.Responses;
using ControleGastos.Communication.Responses.transacao;
using ControleGastos.Exception.ExceptionsBase;
using Microsoft.EntityFrameworkCore;

namespace ControleGastos.API.UseCases.Pessoas.GetId
{
    public class GetPessoaByIdUseCase
    {
        public ResponsePessoaJson Execute(Guid id)
        {
            var dbContext = new ControleGastosHubDbContextc();
            var entity = dbContext
                .Pessoa
                .Include(Pessoa => Pessoa.transacoes)
                .FirstOrDefault(pessoa => pessoa.id == id);



            if (entity is null)
                throw new NotFound("Pessoa não encontrada");

            var total = entity.TotalGasto = entity.transacoes
                .Where(t => t.PessoaID == entity.id)
               .Sum(t => t.valor);

            return new ResponsePessoaJson
            {
                id = id,
                Nome = entity.nome,
                idade = entity.idade,
                transacoes = entity.transacoes.Select(transacao => new ResponseShortTransacaoJson
                {
                    Id = transacao.id,
                    Descricao = transacao.Descricao,
                    
                }).ToList(),
                totalGasto = total
                

            };
        }
    }
}
