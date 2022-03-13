using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TP3_Proyecto_Software.Entities;
using TP3_Proyecto_Software.DTOs;
using TP3_Proyecto_Software.Services;

namespace TP3_Proyecto_Software.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormaEntregaController : Controller
    {

        private readonly FormaEntregaService _service;

        public FormaEntregaController(FormaEntregaService formaEntregaService)
        {
            _service = formaEntregaService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<FormaEntrega>> GetFormasEntrega()
        {
            var listaOutput = _service.ListarFormasEntrega();

            if (listaOutput.Count == 0)
            {
                return NotFound();
            }

            return Ok(listaOutput);
        }


        [HttpGet("{id}")]
        public ActionResult<FormaEntrega> GetFormaEntrega(int id)
        {

            var formaEntrega = _service.GetFormaEntregaPorId(id);

            if (formaEntrega == null)
            {
                return NotFound("No existe la forma de entrega id " + id);
            };

            return Ok(formaEntrega);
        }  

    }
}
