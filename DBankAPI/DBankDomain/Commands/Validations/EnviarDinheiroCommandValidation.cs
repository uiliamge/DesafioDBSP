using System;
using FluentValidation;

namespace DBankAPI.DBankDomain.Commands.Validations
{
    public class EnviarDinheiroCommandValidation : LancamentoValidation<EnviarDinheiroCommand>
    {
        public EnviarDinheiroCommandValidation()
        {
            ValidateConta();
            ValidateValor();

            base.RuleFor(x => x.ContaCorrenteOrigemId)
                .NotEmpty().WithMessage("Em caso de envio de dinheiro é necessário informar a conta de origem");
        }
    }
}
