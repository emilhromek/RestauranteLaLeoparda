using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TP3_Proyecto_Software.Entities
{
    public class FormaEntrega
    {
        [Required]
        public int FormaEntregaId { get; set; }
        [Required, MaxLength(50)]
        public string Descripcion { get; set; }
        [Required]
        public ICollection<Comanda> Comandas { get; set; }
    }
}
