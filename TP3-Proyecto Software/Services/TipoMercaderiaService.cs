using System;
using System.Collections.Generic;
using TP3_Proyecto_Software.Repositories;
using TP3_Proyecto_Software.Entities;
using TP3_Proyecto_Software.DTOs;

namespace TP3_Proyecto_Software.Services
{
    public class TipoMercaderiaService
    {
        private readonly Repository _repository;
        public TipoMercaderiaService(Repository repository)
        {
            _repository = repository;
        }

        public List<object> ListarTiposMercaderia()
        {
            var listaTiposMercaderia = _repository.Traer<TipoMercaderia>();

            var listaOutput = new List<object>();

            foreach (var tipoMercaderia in listaTiposMercaderia)
            {
                var tipoMercaderiaObject = new { id = tipoMercaderia.TipoMercaderiaId, descripcion = tipoMercaderia.Descripcion};

                listaOutput.Add(tipoMercaderiaObject);
            }

            return listaOutput;
        }

        public TipoMercaderia GetTipoMercaderiaPorId(int id)
        {
            var tipoMercaderia = _repository.EncontrarPor<TipoMercaderia>(id);

            return tipoMercaderia;
        }

    }

}
