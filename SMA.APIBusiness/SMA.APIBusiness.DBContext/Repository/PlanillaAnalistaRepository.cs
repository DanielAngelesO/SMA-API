using Dapper;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DBContext
{
    public class PlanillaAnalistaRepository : BaseRepository, IPlanillaAnalistaRepository
    {
        public EntityBaseResponse GetPlanillaAnalistaRepository()
        {
            throw new NotImplementedException();
        }

        public EntityBaseResponse ValidarCeseAnalista(int Codigo_Analista)
        {
            throw new NotImplementedException();
        }
    }
}