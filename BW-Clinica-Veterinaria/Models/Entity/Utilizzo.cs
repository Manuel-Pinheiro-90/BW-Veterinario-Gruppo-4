using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BW_Clinica_Veterinaria.Models.Entity
{
    public class Utilizzo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUtilizzo { get; set; }
        [Required]  
        public string Descrizione { get; set; }
        public List<Prodotto> Prodotti { get; set; } = [];
    }
}
