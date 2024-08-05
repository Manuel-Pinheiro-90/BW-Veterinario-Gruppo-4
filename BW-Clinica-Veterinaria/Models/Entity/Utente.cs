using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BW_Clinica_Veterinaria.Models.Entity
{
    public class Utente
    { [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUtente { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public List<Ruolo> Ruoli { get; set; } = [];
    }
}
