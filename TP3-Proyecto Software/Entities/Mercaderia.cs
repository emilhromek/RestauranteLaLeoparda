using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TP3_Proyecto_Software.Entities
{
    public class Mercaderia
    {
        [Required]
        public int MercaderiaId { get; set; }
        [Required, MaxLength(50)]
        public string Nombre { get; set; }
        public TipoMercaderia TipoMercaderia { get; set; }
        [Required]
        public int TipoMercaderiaId { get; set; }
        [Required]
        public int Precio { get; set; }
        [Required, MaxLength(255)]
        public string Ingredientes { get; set; }
        [Required, MaxLength(255)]
        public string Preparacion { get; set; }
        [Required, MaxLength(255)]
        public string Imagen { get; set; }
        public IList<ComandaMercaderia> ComandaMercaderias { get; set; }
    }
}
