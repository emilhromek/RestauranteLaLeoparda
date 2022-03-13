using System.Collections.Generic;

namespace TP3_Proyecto_Software.DTOs
{
    public class ComandaOutDto
    {
        public string id { get; set; }
        public string formaEntrega { get; set; }
        public int precio { get; set; }
        public string fecha { get; set; }
        public List<object> listaMercaderias { get; set; }
    }
}