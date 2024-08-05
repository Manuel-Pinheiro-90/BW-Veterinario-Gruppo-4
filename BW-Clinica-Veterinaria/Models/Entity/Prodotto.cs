using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BW_Clinica_Veterinaria.Models.Entity
{
    public class Prodotto
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProdotto { get; set; }
        [Required]
        public int IdDitta { get; set; }
        [ForeignKey(nameof(IdDitta))]

        public Ditta Ditta { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        public int IdCassetto { get; set; }
        [ForeignKey(nameof(IdCassetto))]
        public Cassetto Cassetto { get; set; }
       
        public List<Vendita> Vendite { get; set; } = [];
        public List<Utilizzo> Utilizzi { get; set; } = [];


    }
}
