using System.Collections.Generic;

namespace TP3_Proyecto_Software.DTOs
{
    public class ComandaDto
    {
        public int FormaEntregaId { get; set; }
        public List<int> Mercaderia { get; set; }
    }
}