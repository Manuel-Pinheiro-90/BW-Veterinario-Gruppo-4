using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BW_Clinica_Veterinaria.Models.Entity
{
    public class Cassetto
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCassetto { get; set; }
        [Required]
        public int NumeroCassetto { get; set; }
        [Required]
        public int NumeroArmadietto { get; set; }
        public List<Prodotto> Prodotti { get; set; } = [];
    }
}
