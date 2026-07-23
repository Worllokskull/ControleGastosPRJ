# Controle de Gastos Frontend

## Como executar localmente

1. Inicie a API .NET:
   - `dotnet run --project ControleGastos.API/ControleGastos.API.csproj`

2. Em outro terminal, inicie o frontend:
   - `cd frontend-app`
   - `npm install`
   - `npm run dev`

3. Abra o navegador em:
   - http://localhost:3000

A aplicação consome os endpoints da API em:
- GET /api/Pessoas
- POST /api/Pessoas
- GET /api/Pessoas/{id}
- PUT /api/Pessoas/{id}
- DELETE /api/Pessoas/{id}
- POST /api/Transacao/{clientid}
- DELETE /api/Transacao/{id}
