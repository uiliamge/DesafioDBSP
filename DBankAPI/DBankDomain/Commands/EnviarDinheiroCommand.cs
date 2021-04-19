using System;
using DBankAPI.DBankDomain.Commands.Validations;

namespace DBankAPI.DBankDomain.Commands
{
    public class EnviarDinheiroCommand : LancamentoCommand
    {
        public EnviarDinheiroCommand(int contaOrigemId, int contaDestinoId, decimal valor, string obs)
        {
            Operacao = Enums.OperacaoEnum.Credito;
            DataHora = DateTime.Now;

            ContaCorrenteId = contaDestinoId;
            ContaCorrenteOrigemId = contaOrigemId;
            Valor = valor;
            Observacao = obs;
        }

        public override bool IsValid()
        {
            ValidationResult = new EnviarDinheiroCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
