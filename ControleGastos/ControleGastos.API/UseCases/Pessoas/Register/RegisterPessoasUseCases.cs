using ControleGastos.API.Entities;
using ControleGastos.API.Infraestrutura;
using ControleGastos.API.UseCases.Pessoas.Validator;
using ControleGastos.Communication.Requests;
using ControleGastos.Communication.Responses.pessoa;
using ControleGastos.Exception.ExceptionsBase;

namespace ControleGastos.API.UseCases.Pessoas.Register
{
    public class RegisterPessoasUseCases
    {
        public ResponseShortPessoasJson Execute(RequestPessoasJson request)
        {
            validate(request);

            var dbContext = new ControleGastosHubDbContextc();
            var entity = new Pessoa
            {
                nome = request.Nome,
                idade = request.idade
            };
            dbContext.Pessoa.Add(entity);
            dbContext.SaveChanges();
            return new ResponseShortPessoasJson();
        }
        private void validate(RequestPessoasJson request)
        {
            var Validator = new RegisterPessoasValidator();
            var result = Validator.Validate(request);
            if (!result.IsValid)
            {
                var errors = result.Errors.Select(failure => failure.ErrorMessage).ToList();
                throw new ErrorOnValidatorException(errors);
            }
        }
    }
}
