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
    public class LugaresMuestreoRepository : BaseRepository, ILugaresMuestreoRepository
    {
        public EntityBaseResponse GetLugaresMuestreoRepository()
        {
            throw new NotImplementedException();
        }

        public EntityBaseResponse ListLugarProyecto(int Codigo_Cliente)
        {
            throw new NotImplementedException();
        }
    }
}
