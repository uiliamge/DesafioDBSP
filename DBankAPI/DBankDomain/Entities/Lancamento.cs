using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DBankAPI.Enums;

namespace DBankAPI.Entities
{
    public class Lancamento
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DataHora { get; set; }
                
        [Required]
        public int ContaCorrenteId { get; set; }
        public ContaCorrente ContaCorrente { get; set; }

        [Required]
        public OperacaoEnum Operacao { get; set; }

        [Required]
        public decimal Valor { get; set; }

        [MaxLength(60)]
        public string Observacao { get; set; }
    }
}
