using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP3_Proyecto_Software.Entities
{
    public class ComandaMercaderia
    {
        [Required]
        public int ComandaMercaderiaId { get; set; }
        public Mercaderia Mercaderia { get; set; }
        [Required]
        public int MercaderiaId { get; set; }
        public Comanda Comanda { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public string ComandaId { get; set; }
    }
}
