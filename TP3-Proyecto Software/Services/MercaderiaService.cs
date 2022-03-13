using System.Collections.Generic;
using System.Linq;
using TP3_Proyecto_Software.Entities;
using TP3_Proyecto_Software.DTOs;
using TP3_Proyecto_Software.Repositories;
using System.Web;

namespace TP3_Proyecto_Software.Services
{
    public class MercaderiaService
    {
        private readonly Repository _repository;

        public MercaderiaService(Repository repository)
        {
            _repository = repository;
        }

        public List<object> ListarMercaderiasPorTipo(int tipo)
        {

            var buscar = _repository.Traer<Mercaderia>();

            var listaOutput = new List<object>();

            foreach (var x in buscar)
            {
                if (x.TipoMercaderiaId == tipo)
                {
                    var mercaderia = x;

                    var tipoMercaderia = GetTipoMercaderia(mercaderia.TipoMercaderiaId);

                    var tipoMercaderiaObj = new { id = tipoMercaderia.TipoMercaderiaId, descripcion = tipoMercaderia.Descripcion };

                    listaOutput.Add(new
                    {
                        id = mercaderia.MercaderiaId,
                        nombre = mercaderia.Nombre,
                        precio = mercaderia.Precio,
                        tipo = tipoMercaderiaObj,
                        ingredientes = mercaderia.Ingredientes,
                        preparacion = mercaderia.Preparacion,
                        imagen = HttpUtility.UrlPathEncode(mercaderia.Imagen),
                    });
                }
            }

            return listaOutput;
        }

        public List<object> ListarMercaderias()
        {
            var buscar = _repository.Traer<Mercaderia>();

            var listaOutput = new List<object>();

            foreach (var x in buscar)
            {
                var mercaderia = x;

                var tipoMercaderia = GetTipoMercaderia(mercaderia.TipoMercaderiaId);

                var tipoMercaderiaObj = new { id = tipoMercaderia.TipoMercaderiaId, descripcion = tipoMercaderia.Descripcion };

                listaOutput.Add(new
                {
                    id = mercaderia.MercaderiaId,
                    nombre = mercaderia.Nombre,
                    precio = mercaderia.Precio,
                    tipo = tipoMercaderiaObj,
                    ingredientes = mercaderia.Ingredientes,
                    preparacion = mercaderia.Preparacion,
                    imagen = HttpUtility.UrlPathEncode(mercaderia.Imagen),
                });
            }

            return listaOutput;
        }

        public Mercaderia GetMercaderiaPorId(int id)
        {
            var mercaderia = _repository.EncontrarPor<Mercaderia>(id);

            return mercaderia;
        }

        public bool ExisteMercaderia(int id)
        {
            var mercaderia = _repository.EncontrarPor<Mercaderia>(id);
            if (mercaderia == null)
                return false;
            else
                return true;
        }

        public bool ExisteTipoMercaderia(int id)
        {
            var buscarTipoMercaderia = _repository.Traer<TipoMercaderia>().FirstOrDefault(i => i.TipoMercaderiaId == id);

            if (buscarTipoMercaderia == null)
                return false;
            else
                return true;
        }

        public Mercaderia PutMercaderia(int id, MercaderiaDto mercaderia)
        {
            var mercaderiamodificar = _repository.EncontrarPor<Mercaderia>(id);

            mercaderiamodificar.Nombre = mercaderia.Nombre;
            mercaderiamodificar.TipoMercaderiaId = mercaderia.TipoMercaderiaId;
            mercaderiamodificar.Precio = mercaderia.Precio;
            mercaderiamodificar.Ingredientes = mercaderia.Ingredientes;
            mercaderiamodificar.Preparacion = mercaderia.Preparacion;
            mercaderiamodificar.Imagen = HttpUtility.UrlPathEncode(mercaderia.Imagen);

            _repository.Actualizar(mercaderiamodificar);

            return mercaderiamodificar;
        }

        public Mercaderia PostMercaderia(MercaderiaDto mercaderia)
        {
            var mercaderiaNueva = new Mercaderia()
            {
                Nombre = mercaderia.Nombre,
                TipoMercaderiaId = mercaderia.TipoMercaderiaId,
                Precio = mercaderia.Precio,
                Ingredientes = mercaderia.Ingredientes,
                Preparacion = mercaderia.Preparacion,
                Imagen = HttpUtility.UrlPathEncode(mercaderia.Imagen),
            };

            _repository.Agregar<Mercaderia>(mercaderiaNueva);

            return mercaderiaNueva;
        }

        public bool mercaderiaEstaEnUso(int id)
        {
            var mercaderia = GetMercaderiaPorId(id);

            foreach (ComandaMercaderia comandaMercaderia in _repository.Traer<ComandaMercaderia>())
            {
                if (comandaMercaderia.MercaderiaId == mercaderia.MercaderiaId)
                {
                    return true;
                }
            }

            return false;
        }

        public Mercaderia DeleteMercaderia(int id)
        {
            var mercaderia = GetMercaderiaPorId(id);

            _repository.BorrarPor<Mercaderia>(id);

            return mercaderia;
        }

        public TipoMercaderia GetTipoMercaderia(int id)
        {
            return _repository.EncontrarPor<TipoMercaderia>(id);
        }

        public object MostrarMercaderia(int id)
        {
            var mercaderia = GetMercaderiaPorId(id);

            var tipoMercaderia = GetTipoMercaderia(mercaderia.TipoMercaderiaId);

            var tipoMercaderiaObj = new { id = tipoMercaderia.TipoMercaderiaId, descripcion = tipoMercaderia.Descripcion };

            return new
            {
                id = mercaderia.MercaderiaId,
                nombre = mercaderia.Nombre,
                tipo = tipoMercaderiaObj,
                precio = mercaderia.Precio,
                ingredientes = mercaderia.Ingredientes,
                preparacion = mercaderia.Preparacion,
                imagen = mercaderia.Imagen,
            };
        }

        public List<string> ComandasAsociadasAUnaMercaderia(int id)
        {
            var mercaderia = GetMercaderiaPorId(id);

            List<string> listaDeIds = new List<string>();

            foreach (ComandaMercaderia comandaMercaderia in _repository.Traer<ComandaMercaderia>())
            {
                if (comandaMercaderia.MercaderiaId == id && !listaDeIds.Contains(comandaMercaderia.ComandaId))
                {
                    listaDeIds.Add(comandaMercaderia.ComandaId);
                }
            }
            return listaDeIds;
        }
        public string MensajeComandasAsociadasAUnaMercaderia(int id)
        {
            string message = "La mercaderia esta en uso por la siguientes comandas: \n";

            foreach (string comandaId in ComandasAsociadasAUnaMercaderia(id))
            {
                message = message + "\n" + comandaId;
            }

            return message;
        }

    }
}
