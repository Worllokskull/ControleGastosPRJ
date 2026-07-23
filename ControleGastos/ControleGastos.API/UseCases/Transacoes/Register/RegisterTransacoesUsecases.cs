using ControleGastos.API.Entities;
using ControleGastos.API.Infraestrutura;
using ControleGastos.API.UseCases.Pessoas.Register;
using ControleGastos.API.UseCases.Pessoas.Validator;
using ControleGastos.API.UseCases.Transacoes.Validator;
using ControleGastos.Communication.Requests;
using ControleGastos.Communication.Responses;
using ControleGastos.Communication.Responses.pessoa;
using ControleGastos.Communication.Responses.transacao;
using ControleGastos.Exception.ExceptionsBase;

namespace ControleGastos.API.UseCases.Transacoes.Register
{
    public class RegisterTransacoesUsecases
    {
        public ResponseShortTransacaoJson Execute(Guid clientid, RequestTransacoesJson request)
        {
            var dbContext = new ControleGastosHubDbContextc();
            validate(dbContext, clientid, request);
            var desp = false;
             if (dbContext.Pessoa.First(pessoa => pessoa.id == clientid).idade >= 18)
                {
                desp = true;
                }
            var entity = new Transacao
            {
                Descricao = request.Descricao,
                valor = request.valor,
                despesa = desp,
                PessoaID = clientid
            };
            dbContext.transacaos.Add(entity);
            dbContext.SaveChanges();
            return new ResponseShortTransacaoJson()
            {
                Id = entity.id,
                Descricao = entity.Descricao
            };
        }
        private void validate(ControleGastosHubDbContextc dbContext, Guid clientid, RequestTransacoesJson request)
        {
            if ((dbContext.Pessoa.Any(pessoa => pessoa.id == clientid)) == false)
            {
                throw new NotFound("Pessoa nao existe");
            }
            
            var Validator = new ValidatorTransacoesUseCases();
            var result = Validator.Validate(request);
            if (!result.IsValid)
            {
                var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();
                throw new ErrorOnValidatorException(errors);
            }
        }
    }
}
