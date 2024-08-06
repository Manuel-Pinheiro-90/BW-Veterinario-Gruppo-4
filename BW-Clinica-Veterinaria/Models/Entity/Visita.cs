using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BW_Clinica_Veterinaria.Models.Entity
{
    public class Visita
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdVista { get; set; }
        [Required]
        public int IdAnimale  { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        public string Esame {  get; set; }
        [Required]
        public string  CuraPrescritta { get; set; }
        [ForeignKey (nameof(IdAnimale))]
        public Animale Animale { get; set; }
    }
}
