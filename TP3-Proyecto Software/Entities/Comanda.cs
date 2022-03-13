using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP3_Proyecto_Software.Entities
{
    public class Comanda
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required, Key]
        public string ComandaId { get; set; }
        public FormaEntrega FormaEntrega { get; set; }
        [Required]
        public int FormaEntregaId { get; set; }
        [Required]
        public int PrecioTotal { get; set; }
        [Required, DataType(DataType.Date), Column(TypeName = "Date")]
        public DateTime Fecha { get; set; }
        public ICollection<ComandaMercaderia> ComandaMercaderias { get; set; }
    }
}
