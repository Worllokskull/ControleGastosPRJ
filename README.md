💰 Controle de Gastos Familiar

Aplicação Full Stack desenvolvida para gerenciamento de pessoas e suas transações financeiras.

O projeto possui uma API REST desenvolvida em C#/.NET, persistência de dados utilizando SQLite e uma interface frontend responsável pela interação com a aplicação.

🚀 Funcionalidades

👤 Pessoas

- Cadastrar pessoas
- Listar pessoas
- Buscar pessoa por ID
- Atualizar informações
- Excluir pessoas

💳 Transações

- Registrar transações associadas a uma pessoa
- Excluir transações
- Gerenciar os gastos associados aos usuários

🛠️ Tecnologias

Backend

- C#
- .NET
- API REST
- SQLite

Frontend

- JavaScript
- HTML
- CSS

Ferramentas

- Git
- GitHub
- Visual Studio
- Visual Studio Code

📁 Estrutura do projeto

ControleGastos/
├── ControleGastos.API/
├── ControleGastos.Communication/
├── ControleGastos.Exception/
├── ControleGastos.Frontend/
├── frontend-app/
└── ControleGastos.slnx

A aplicação foi organizada separando as diferentes responsabilidades do projeto, facilitando a manutenção e evolução do código.

🔗 Endpoints

Pessoas

GET /api/Pessoas
POST /api/Pessoas
GET /api/Pessoas/{id}
PUT /api/Pessoas/{id}
DELETE /api/Pessoas/{id}

Transações

POST /api/Transacao/{clientid}
DELETE /api/Transacao/{id}

▶️ Como executar

1. Clone o repositório

git clone https://github.com/Worllokskull/ControleGastosPRJ.git

Entre na pasta:

cd ControleGastosPRJ

2. Execute a API

dotnet run --project "ControleGastos/ControleGastos.API/ControleGastos.API.csproj"

A API será iniciada localmente e estará pronta para receber as requisições do frontend.

3. Execute o frontend

Abra outro terminal e execute:

cd "ControleGastos/frontend-app"
npm install
npm run dev

Depois, acesse no navegador o endereço informado pelo Vite no terminal.

💾 Banco de dados

O projeto utiliza SQLite para persistência dos dados da aplicação.

Essa abordagem permite armazenar as informações utilizadas pelo sistema de forma local e integrada ao backend.

🎯 Objetivo do projeto

O projeto foi desenvolvido com o objetivo de colocar em prática conceitos de desenvolvimento Full Stack, incluindo:

- Desenvolvimento de APIs REST
- Integração entre frontend e backend
- Persistência de dados com SQLite
- Operações de cadastro, consulta, atualização e exclusão
- Organização e separação das responsabilidades da aplicação
- Versionamento de código com Git e GitHub

👨‍💻 Autor

Lucas Felipe Meneses Silva

Estudante de Ciência da Computação e desenvolvedor Full Stack em formação.

"LinkedIn" (https://linkedin.com/in/lucasfelipemeneses/) • "GitHub" (https://github.com/Worllokskull)
