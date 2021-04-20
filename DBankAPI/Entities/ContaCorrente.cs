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
        public string UserName { get; set; }

        [Required]
        public int Numero { get; set; }

        public ICollection<Lancamento> Lancamentos { get; set; }

    }
}
