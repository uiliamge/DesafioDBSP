using System;
namespace DBankAPI.ViewModels
{
    public class LancamentoViewModel
    {
        public DateTime DataHora { get; protected set; }
        public int ContaCorrenteOrigemId { get; protected set; }
        public int ContaCorrenteId { get; protected set; }      
        public decimal Valor { get; protected set; }
        public string Observacao { get; protected set; }
    }
}
