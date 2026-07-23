using ControleGastos.Communication.Requests;
using FluentValidation;

namespace ControleGastos.API.UseCases.Pessoas.Validator
{
    public class RegisterPessoasValidator : AbstractValidator<RequestPessoasJson>
    {
        public RegisterPessoasValidator()
        {
            RuleFor(pessoas => pessoas.Nome).NotEmpty().WithMessage("O nome não pode estar vazio");
            RuleFor(pessoas => pessoas.idade).GreaterThan(0).WithMessage("A idade não pode ser menor que 1");
        }
    }
}
