using ControleGastos.Communication.Requests;
using FluentValidation;

namespace ControleGastos.API.UseCases.Transacoes.Validator
{
    public class ValidatorTransacoesUseCases : AbstractValidator<RequestTransacoesJson>
    {
        public ValidatorTransacoesUseCases()
        {
            RuleFor(transacion => transacion.Descricao).NotEmpty().WithMessage("A descricao nao pode estar vazia");
            RuleFor(transacion => transacion.valor).GreaterThan(0).WithMessage("O valor nao pode ser menor que 1");
        }
    }
}
