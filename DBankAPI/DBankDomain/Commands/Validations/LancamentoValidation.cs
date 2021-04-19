using System;
using FluentValidation;

namespace DBankAPI.DBankDomain.Commands.Validations
{
    public abstract class LancamentoValidation<T> : AbstractValidator<T> where T : LancamentoCommand
    {
        protected void ValidateConta()
        {
            RuleFor(c => c.ContaCorrenteId)
                .NotEmpty().WithMessage("Conta não informada");
        }

        protected void ValidateValor()
        {
            RuleFor(c => c.Valor)
                .GreaterThan(0)
                .NotEmpty().WithMessage("Valor deve ser maior que zero");
        }
    }
}
