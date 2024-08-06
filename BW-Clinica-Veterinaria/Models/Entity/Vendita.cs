using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BW_Clinica_Veterinaria.Models.Entity
{
    public class Vendita
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdVendita { get; set; }
        [Required]
        public string CodiceFiscaleCliente  { get; set; }
        [Required]
        public int IdProdotto { get; set; }
        [Required]
        public DateTime Data { get; set; } = DateTime.Now;
        public string Ricetta { get; set; }
        [ForeignKey(nameof(CodiceFiscaleCliente))]
        public Proprietario Proprietario { get; set; }
        [ForeignKey(nameof(IdProdotto))]
        public Prodotto Prodotto { get; set; }
    }
}
