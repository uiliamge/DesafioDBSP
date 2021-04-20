using System;
using DBankAPI.Enums;

namespace DBankAPI.ViewModels
{
    public class ExtratoViewModel
    {
        public DateTime DataHora { get; set; }
        public int ContaCorrenteId { get; set; }
        public string Operacao { get; set; }
        public decimal Valor { get; set; }
        public string Observacao { get; set; }
    }
}
