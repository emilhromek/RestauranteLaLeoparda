using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TP3_Proyecto_Software.Entities;
using TP3_Proyecto_Software.DTOs;
using TP3_Proyecto_Software.Services;

namespace TP3_Proyecto_Software.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComandaController : Controller
    {
        private readonly ComandaService _service;

        public ComandaController(ComandaService service)
        {
            _service = service;
        }

        // Punto 3, obtener comandas pero filtradas por fecha con detalle de mercaderia

        [HttpGet]
        public ActionResult<IEnumerable<Comanda>> GetComandaFecha([FromQuery] string fecha)
        {
            var listaComandasFecha = _service.ListarComandasPorFecha(fecha);

            if (listaComandasFecha.Count == 0)
            {
                return NotFound("No existe esa fecha.\nFormato de fecha pedido: dd-mm-aaaa o d-mm-aaaa o dd-m-aaaa (sin 0 a la izquierda)");
            }

            return Ok(listaComandasFecha);
        }


        // Punto 8, obtener comanda por id

        [HttpGet("{id}")]
        public ActionResult<Comanda> GetComanda(string id)
        {
            var comanda = _service.GetComandaId(id);

            if (comanda == null)
            {
                return NotFound();
            }

            return Ok(_service.MostrarComandaConMercaderias(id));
        }

        // Punto 2, guardar comanda

        [HttpPost]
        public ActionResult<object> PostComanda(ComandaDto comanda)
        {

            // Check si existe forma de entrega

            var existeFormaEntrega = _service.ExisteTipoEntrega(comanda.FormaEntregaId);

            if (existeFormaEntrega == false)
            {
                return BadRequest("No existe esa forma de entrega");
            }

            // Check si existen todas la mercaderias

            foreach (int mercaderiaId in comanda.Mercaderia)
            {
                var existeMercaderia = _service.ExisteMercaderia(mercaderiaId);

                if (existeMercaderia == false)
                {
                    return BadRequest("No existe la mercaderia con id " + mercaderiaId);
                }
            }

            var mostrar = _service.PostComanda(comanda);

            return CreatedAtAction("PostComanda", mostrar);
        }

    }
}
