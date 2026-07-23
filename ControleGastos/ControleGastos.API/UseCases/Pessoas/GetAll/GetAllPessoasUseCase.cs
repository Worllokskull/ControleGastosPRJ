using ControleGastos.API.Infraestrutura;
using ControleGastos.Communication.Responses.pessoa;

namespace ControleGastos.API.UseCases.Pessoas.GetAll
{
    public class GetAllPessoasUseCase
    {

        public ResponseAllPessoasJson Execute()
        {
            var dbContext = new ControleGastosHubDbContextc();
            var pessoas = dbContext.Pessoa.ToList();


            return new ResponseAllPessoasJson
            {
                Pessoas = pessoas.Select(pessoas => new ResponseShortPessoasJson
                {
                    id = pessoas.id,
                    Nome = pessoas.nome
                }).ToList()
            };
        }
    }
}
