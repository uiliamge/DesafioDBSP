using System;
using FluentValidation;

namespace DBankAPI.DBankDomain.Commands.Validations
{
    public class DebitarDaOrigemCommandValidation : LancamentoValidation<DebitarDaOrigemCommand>
    {
        public DebitarDaOrigemCommandValidation()
        {
            ValidateConta();
            ValidateValor();

            base.RuleFor(x => x.Observacao)
                .NotEmpty().WithMessage("Em caso de débito é necessário informar uma observação");
        }
    }
}
