using System;
using DBankAPI.DBankDomain.Commands.Validations;

namespace DBankAPI.DBankDomain.Commands
{
    public class DebitarDaOrigemCommand : LancamentoCommand
    {
        public DebitarDaOrigemCommand(int contaDebitadaId, string strContaCreditada, decimal valor)
        {
            Operacao = Enums.OperacaoEnum.Debito;
            DataHora = DateTime.Now;

            ContaCorrenteId = contaDebitadaId;
            Valor = valor;
            Observacao = $"Referente à crédito na conta {strContaCreditada}";
        }

        public override bool IsValid()
        {
            ValidationResult = new DebitarDaOrigemCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
