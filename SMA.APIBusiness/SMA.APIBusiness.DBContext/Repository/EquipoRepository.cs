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
        public EntityBaseResponse ListarEquipos()
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    var servicio = new List<EntityOrdenServcioConsulta>();
                    const string sql = "usp_ListarOrdenesServicios";
                    servicio = db.Query<EntityOrdenServcioConsulta>(
                            sql: sql,
                            commandType: CommandType.StoredProcedure
                        ).ToList();

                    if (servicio.Count > 0)
                    {
                        response.Issuccess = true;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = String.Empty;
                        response.Data = servicio;
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

        public EntityBaseResponse ListEquipoRepository(int Codigo_Equipo)
        {
            throw new NotImplementedException();
        }

        
        }
}
