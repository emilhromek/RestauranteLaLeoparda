using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TP3_Proyecto_Software.Entities;
using TP3_Proyecto_Software.DTOs;
using TP3_Proyecto_Software.Services;

namespace TP3_Proyecto_Software.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoMercaderiaController : Controller
    {

        private readonly TipoMercaderiaService _service;

        public TipoMercaderiaController(TipoMercaderiaService tipoMercaderiaService)
        {
            _service = tipoMercaderiaService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TipoMercaderia>> GetTiposMercaderia()
        {
            var listaOutput = _service.ListarTiposMercaderia();

            if (listaOutput.Count == 0)
            {
                return NotFound();
            }

            return Ok(listaOutput);
        }


        [HttpGet("{id}")]
        public ActionResult<TipoMercaderia> GetTipoMercaderia(int id)
        {

            var tipoMercaderia = _service.GetTipoMercaderiaPorId(id);

            if (tipoMercaderia == null)
            {
                return NotFound("No existe el tipo de mercaderia id " + id);
            };

            return Ok(tipoMercaderia);
        }  

    }
}
