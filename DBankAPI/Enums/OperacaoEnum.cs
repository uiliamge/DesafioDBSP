using System;
using System.ComponentModel;

namespace DBankAPI.Enums
{
    public enum OperacaoEnum
    {
        [Description("Débito")]
        Debito,

        [Description("Crédito")]
        Credito
    }
}
