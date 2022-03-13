using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TP3_Proyecto_Software.Entities;
using TP3_Proyecto_Software.DTOs;
using TP3_Proyecto_Software.Services;

namespace TP3_Proyecto_Software.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MercaderiaController : Controller
    {

        private readonly MercaderiaService _service;

        public MercaderiaController(MercaderiaService mercaderiaService)
        {
            _service = mercaderiaService;
        }

        // Punto 4, obtener mercaderias pero filtradas por tipo

        [HttpGet]
        public ActionResult<IEnumerable<Mercaderia>> GetMercaderiaQuery([FromQuery] int tipo)
        {
            if (tipo == 0)
            {
                return Ok(_service.ListarMercaderias());
            }

            var listaOutput = _service.ListarMercaderiasPorTipo(tipo);

            if (listaOutput.Count == 0)
            {
                return NotFound("No hay mercaderias de tipo " + tipo);
            }

            return Ok(listaOutput);
        }


        //Punto 7, buscar mercaderia por id

        [HttpGet("{id}")]
        public ActionResult<Mercaderia> GetMercaderia(int id)
        {

            var mercaderia = _service.GetMercaderiaPorId(id);

            if (mercaderia == null)
            {
                return NotFound("No existe la mercaderia con id " + id);
            };

            return Ok(_service.MostrarMercaderia(id));
        }

        // Punto 5, modificar informacion de mercaderia

        [HttpPut("{id}")]
        public IActionResult PutMercaderia(int id, MercaderiaDto mercaderia)
        {
            var existeMercaderia = _service.ExisteMercaderia(id);

            if (existeMercaderia == false)
            {
                return NotFound("No existe la mercaderia con id " + id);
            }

            var existeTipoMercaderia = _service.ExisteTipoMercaderia(id);

            if (existeTipoMercaderia == false)
            {
                return BadRequest("No existe ese tipo de mercaderia");
            }

            _service.PutMercaderia(id, mercaderia);

            return Ok(_service.MostrarMercaderia(id));
        }

        // Punto 1, guardar mercaderia

        [HttpPost]
        public ActionResult<Mercaderia> PostMercaderia(MercaderiaDto mercaderia)
        {
            var existeTipoMercaderia = _service.ExisteTipoMercaderia(mercaderia.TipoMercaderiaId);

            if (existeTipoMercaderia == false)
            {
                return BadRequest("No existe ese tipo de mercaderia");
            }

            var checkLargoNombre = mercaderia.Nombre.Length;
            if (checkLargoNombre > 50)
            {
                return BadRequest("El nombre supera los 50 caracteres.");
            }

            var checkLargoIngredientes = mercaderia.Ingredientes.Length;
            if (checkLargoIngredientes > 255)
            {
                return BadRequest("Los ingredientes supera los 255 caracteres.");
            }

            var checkLargoPreparacion = mercaderia.Preparacion.Length;
            if (checkLargoPreparacion > 255)
            {
                return BadRequest("La preparacion supera los 255 caracteres.");
            }

            var checkLargoImagen = mercaderia.Imagen.Length;
            if (checkLargoImagen > 255)
            {
                return BadRequest("La direccion de imagen supera los 255 caracteres.");
            }

            var mercaderiaNueva = _service.PostMercaderia(mercaderia);

            return CreatedAtAction("PostMercaderia", _service.MostrarMercaderia(mercaderiaNueva.MercaderiaId));
        }


        // Punto 6, borrar mercaderia

        [HttpDelete("{id}")]
        public ActionResult<Mercaderia> DeleteMercaderia(int id)
        {
            var mercaderia = _service.GetMercaderiaPorId(id);

            if (mercaderia == null)
            {
                return NotFound("No se encontró la mercaderia con id " + id);
            }

            if (_service.mercaderiaEstaEnUso(id) == true)
            {
                return BadRequest(_service.MensajeComandasAsociadasAUnaMercaderia(id));
            }

            string guardarNombre = mercaderia.Nombre;

            _service.DeleteMercaderia(id);

            return Ok("Borrado ok de la mercaderia con id " + id + " (" + guardarNombre + ")");
        }
    }
}
