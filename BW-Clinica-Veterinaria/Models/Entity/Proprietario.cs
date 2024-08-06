using System.ComponentModel.DataAnnotations;

namespace BW_Clinica_Veterinaria.Models.Entity
{
    public class Proprietario
    {
        [Key]
        public string CodiceFiscale { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cognome{ get; set; }
        [Required]
        public int NumeroTelefono { get; set; }
        public List<Animale> Animali { get; set; } = [];
    }
}
