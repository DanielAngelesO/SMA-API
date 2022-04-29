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
    public class EquipoRepository : BaseRepository, IEquipoRepository
    {
        public EntityBaseResponse GetEquipoRepository()
        {
            throw new NotImplementedException();
        }

        public EntityBaseResponse ListEquipoRepository(int Codigo_Equipo)
        {
            throw new NotImplementedException();
        }
    }
}
