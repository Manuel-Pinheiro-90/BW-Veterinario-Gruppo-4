using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BW_Clinica_Veterinaria.Models.Entity
{
    public class Animale
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAnimale {  get; set; }
        public string Name { get; set; }
        [Required]
        public string Tipologia { get; set; }
        [Required]
        public string Colore { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string MicroChipCodice { get; set; }
        [Required]
        public DateTime DataNascita { get; set; } 
        [Required]
         public DateTime DataRegistrazione { get; set; } = DateTime.Now;
        public string CodiceFiscaleProprietario { get; set; }
        [ForeignKey(nameof(CodiceFiscaleProprietario))]
        public Proprietario Proprietario { get; set; }
    }
}
