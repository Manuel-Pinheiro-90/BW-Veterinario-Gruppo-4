using BW_Clinica_Veterinaria.Models.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BW_Clinica_Veterinaria.Dto
{
    public class RicoveroDto
    {
        [Required]
        public DateTime DataRicovero { get; set; } = DateTime.Now;
        [Required]
        public IFormFile Foto { get; set; }
        [Required]
        public int IdAnimale { get; set; }
    }
}
