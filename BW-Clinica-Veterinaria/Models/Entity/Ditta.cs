using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BW_Clinica_Veterinaria.Models.Entity
{
    public class Ditta
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDitta { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Indirizzo { get; set; }
        [Required]
        public string Recapito { get; set; }
       
    }
}
