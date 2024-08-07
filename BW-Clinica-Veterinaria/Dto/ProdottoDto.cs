using BW_Clinica_Veterinaria.Models.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BW_Clinica_Veterinaria.Dto
{
    public class ProdottoDto
    {
        [Required]
        public int IdDitta { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        public int IdCassetto { get; set; }
        public List<Utilizzo> Utilizzi { get; set; } = [];
    }
}
