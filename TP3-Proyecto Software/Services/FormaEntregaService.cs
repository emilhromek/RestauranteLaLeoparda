using System;
using System.Collections.Generic;
using TP3_Proyecto_Software.Repositories;
using TP3_Proyecto_Software.Entities;
using TP3_Proyecto_Software.DTOs;

namespace TP3_Proyecto_Software.Services
{
    public class FormaEntregaService
    {
        private readonly Repository _repository;
        public FormaEntregaService(Repository repository)
        {
            _repository = repository;
        }

        public List<object> ListarFormasEntrega()
        {
            var listaFormasEntrega = _repository.Traer<FormaEntrega>();

            var listaOutput = new List<object>();

            foreach (var formaEntrega in listaFormasEntrega)
            {
                var formaEntregaObject = new { id = formaEntrega.FormaEntregaId, descripcion = formaEntrega.Descripcion };

                listaOutput.Add(formaEntregaObject);
            }

            return listaOutput;
        }

        public FormaEntrega GetFormaEntregaPorId(int id)
        {
            var formaEntrega = _repository.EncontrarPor<FormaEntrega>(id);

            return formaEntrega;
        }

    }

}
