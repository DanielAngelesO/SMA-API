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
    public class PlanillaAnalistaRepository : BaseRepository, IPlanillaAnalistaRepository
    {
        public EntityBaseResponse GetAnalistas()
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    var analistas = new List<EntityPlanillaAnalista>();
                    const string sql = "usp_ListarAnalistas";
                    analistas = db.Query<EntityPlanillaAnalista>(
                            sql: sql,
                            commandType: CommandType.StoredProcedure
                        ).ToList();

                    if (analistas.Count > 0)
                    {
                        response.Issuccess = true;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = String.Empty;
                        response.Data = analistas;
                    }
                    else
                    {
                        response.Issuccess = false;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = String.Empty;
                        response.Data = null;
                    }
                }

            }
            catch (Exception ex)
            {
                response.Issuccess = false;
                response.ErrorCode = "0001";
                response.ErrorMessage = ex.Message;
                response.Data = null;
            }

            return response;
        }

        public EntityBaseResponse ValidarCeseAnalista(int Codigo_Analista)
        {
            throw new NotImplementedException();
        }
    }
}
