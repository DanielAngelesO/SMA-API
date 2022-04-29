using Dapper;
using DBEntity;
using SMA.APIBusiness.DBContext.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DBContext
{
    public class AnalistaProyectoRepository : BaseRepository, IAnalistaProyectoRepository
    {
        public EntityBaseResponse GetAnalistaProyectoRepository()
        {
            throw new NotImplementedException();
        }

        public EntityBaseResponse ObtenerAnalista(string Codigo_Analista)
        {
            throw new NotImplementedException();
        }
    }
}
