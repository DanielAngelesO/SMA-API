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
    public class PlanProyectoRepository : BaseRepository, IPlanProyectoRepository
    {
        public EntityBaseResponse GetPlanProyectoRepository()
        {
            throw new NotImplementedException();
        }

        public EntityBaseResponse ListPlan(int Codigo_Cliente)
        {
            throw new NotImplementedException();
        }
    }
}
