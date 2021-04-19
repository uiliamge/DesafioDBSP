using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBankAPI.Entities
{
    public class ContaCorrente
    {
        public ContaCorrente()
        {
            Lancamentos = new HashSet<Lancamento>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int Numero { get; set; }

        [Required]
        public char Digito { get; set; }

        public ICollection<Lancamento> Lancamentos { get; set; }

        /// <summary>
        /// Retorna {Numero}-{Digito} 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Numero}-{Digito}";
        }
    }
}
