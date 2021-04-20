using System;
namespace DBankAPI.ViewModels
{
    public class LancamentoViewModel
    {
        public int ContaCorrenteOrigem { get; set; }      
        public int ContaCorrenteDestino { get; set; }      
        public decimal Valor { get; set; }
        public string Observacao { get; set; }
    }
}
