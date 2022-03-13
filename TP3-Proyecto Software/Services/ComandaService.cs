using System;
using System.Collections.Generic;
using TP3_Proyecto_Software.Repositories;
using TP3_Proyecto_Software.Entities;
using TP3_Proyecto_Software.DTOs;

namespace TP3_Proyecto_Software.Services
{
    public class ComandaService
    {
        private readonly Repository _repository;
        public ComandaService(Repository repository)
        {
            _repository = repository;
        }

        public List<ComandaOutDto> ListarComandasPorFecha(string fecha)
        {
            var listaComandas = _repository.Traer<Comanda>();

            var listaOutput = new List<ComandaOutDto>();

            foreach (var comanda in listaComandas)
            {
                string fechaCorregida = comanda.Fecha.ToString("yyyy-MM-dd HH:mm:ss").Substring(0, 10);

                if (fechaCorregida.Equals(fecha))
                {
                    //var comandaObject = new { id = comanda.ComandaId, formaEntrega= _repository.EncontrarPor<FormaEntrega>(comanda.FormaEntregaId).Descripcion, precio = comanda.PrecioTotal, fecha = comanda.Fecha.ToShortDateString(), listaMercaderias = ListarMercaderiasDeComanda(comanda) };

                    var comandaObject = new ComandaOutDto{ id = comanda.ComandaId, formaEntrega = _repository.EncontrarPor<FormaEntrega>(comanda.FormaEntregaId).Descripcion, precio = comanda.PrecioTotal, fecha = comanda.Fecha.ToShortDateString(), listaMercaderias = ListarMercaderiasDeComanda(comanda) };

                    listaOutput.Add(comandaObject);
                }
            }

            listaOutput.Sort((x, y) =>
            x.precio.CompareTo(y.precio));

            return listaOutput;
        }

        public Object MostrarComandaConMercaderias(string id)
        {
            var comanda = _repository.EncontrarPorGuid<Comanda>(id);

            var comandaMercaderias = _repository.Traer<ComandaMercaderia>();

            var listaMercaderiasMostrar = new List<object>();

            foreach (var comandaMercaderia in comandaMercaderias)
            {
                if (comanda.ComandaId.Equals(comandaMercaderia.ComandaId))
                {
                    var mercaderia = _repository.EncontrarPor<Mercaderia>(comandaMercaderia.MercaderiaId);

                    var mercaderiaObject = new { nombre = mercaderia.Nombre, tipo = _repository.EncontrarPor<TipoMercaderia>(mercaderia.TipoMercaderiaId).Descripcion };

                    listaMercaderiasMostrar.Add(mercaderiaObject);
                }
            }

            return new { id = comanda.ComandaId, precio = comanda.PrecioTotal, fecha = comanda.Fecha.ToShortDateString(), mercaderias = listaMercaderiasMostrar };
        }

        public List<object> ListarMercaderiasDeComanda(Comanda comanda)
        {

            var listaComandaMercaderias = _repository.Traer<ComandaMercaderia>();

            var listaOutput = new List<object>();

            foreach (var comandaMercaderia in listaComandaMercaderias)
            {
                if (comandaMercaderia.ComandaId == comanda.ComandaId)
                {
                    var mercaderia = _repository.EncontrarPor<Mercaderia>(comandaMercaderia.MercaderiaId);

                    var mercaderiaObject = new
                    {
                        nombre = mercaderia.Nombre,
                        tipo = _repository.EncontrarPor<TipoMercaderia>(mercaderia.TipoMercaderiaId).Descripcion
                    };

                    listaOutput.Add(mercaderiaObject);

                }
            }

            return listaOutput;
        }

        public Comanda GetComandaId(string id)
        {
            var comanda = _repository.EncontrarPorGuid<Comanda>(id);

            return comanda;
        }

        public bool ExisteTipoEntrega(int id)
        {
            var tipoEntrega = _repository.EncontrarPor<FormaEntrega>(id);

            if (tipoEntrega == null)
                return false;
            else
                return true;
        }

        public bool ExisteMercaderia(int id)
        {
            var mercaderia = _repository.EncontrarPor<Mercaderia>(id);

            if (mercaderia == null)
                return false;
            else
                return true;
        }

        public Mercaderia GetMercaderia(int id)
        {
            return _repository.EncontrarPor<Mercaderia>(id);
        }

        public object PostComanda(ComandaDto comanda)
        {
            int precioTotal = 0;

            var comandaNueva = new Comanda
            {
                FormaEntregaId = comanda.FormaEntregaId,
                Fecha = DateTime.Now,
            };

            var listaComandMercaderia = new List<ComandaMercaderia>();

            foreach (int mercaderiaid in comanda.Mercaderia)
            {
                ComandaMercaderia comandamercaderia = new ComandaMercaderia();
                comandamercaderia.MercaderiaId = mercaderiaid;
                listaComandMercaderia.Add(comandamercaderia);
                var mercaderia = GetMercaderia(mercaderiaid);
                precioTotal = precioTotal + mercaderia.Precio;
            }

            comandaNueva.ComandaMercaderias = listaComandMercaderia;
            comandaNueva.PrecioTotal = precioTotal;

            _repository.Agregar<Comanda>(comandaNueva);

            return new { id = comandaNueva.ComandaId, precioTotal = comandaNueva.PrecioTotal, fecha = comandaNueva.Fecha.ToShortDateString(), listaMercaderias = ListarMercaderiasDeComanda(comandaNueva) };
        }

    }

}
