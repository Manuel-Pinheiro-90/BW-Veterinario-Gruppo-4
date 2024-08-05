using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BW_Clinica_Veterinaria.Models.Entity
{
    public class Ruolo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRuolo { get; set; }
        [Required]
        public string Nome { get; set; }
        public List<Utente> Utente { get; set; } = [];
    }
}
