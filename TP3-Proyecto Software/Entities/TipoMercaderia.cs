using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TP3_Proyecto_Software.Entities
{
    public class TipoMercaderia
    {
        [Required]
        public int TipoMercaderiaId { get; set; }
        [Required, MaxLength(50)]
        public string Descripcion { get; set; }
        public ICollection<Mercaderia> Mercaderias;

    }
}
