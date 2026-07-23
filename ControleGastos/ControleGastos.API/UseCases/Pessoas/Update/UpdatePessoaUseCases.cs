using ControleGastos.API.Infraestrutura;
using ControleGastos.API.UseCases.Pessoas.Register;
using ControleGastos.API.UseCases.Pessoas.Validator;
using ControleGastos.Communication.Requests;
using ControleGastos.Exception.ExceptionsBase;

namespace ControleGastos.API.UseCases.Pessoas.Update
{
    public class UpdatePessoaUseCases
    {
        public void Execute(Guid pessoaid, RequestPessoasJson request)
        {
            validate(request);
            var dbContext = new ControleGastosHubDbContextc();

            var entity = dbContext.Pessoa.FirstOrDefault(pessoa => pessoa.id == pessoaid);
            if (entity == null) 
                throw new NotFound("Pessoa não encontrada.");

            entity.nome = request.Nome;
            entity.idade = request.idade;

            dbContext.Pessoa.Update(entity);
            dbContext.SaveChanges();
            
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
