using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BW_Clinica_Veterinaria.Models.Entity
{
    public class Ricovero
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRicovero { get; set; }
        [Required]
        public DateTime DataRicovero { get; set; }
        public DateTime? DataFineRicovero { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Foto { get; set; }
        [Required]
        public int IdAnimale { get; set; }
        [ForeignKey(nameof(IdAnimale))]
        public Animale Animale {  get; set; }
    }
}
