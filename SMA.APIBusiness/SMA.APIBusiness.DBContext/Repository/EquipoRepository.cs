using Dapper;
using DBEntity;
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
                    var servicio = new List<EntityEquipo>();
                    const string sql = "ups_ListarEquipos";
                    servicio = db.Query<EntityEquipo>(
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

        public EntityBaseResponse ListarEquipos(string Codigo_Equipo)
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    var servicio = new List<EntityEquipo>();
                    const string sql = "ups_ListarEquipos_x_Codigo";
                    var p = new DynamicParameters();

                    p.Add(name: "COD_EQUIPO", value: Codigo_Equipo, dbType: DbType.String, direction: ParameterDirection.Input);

                    servicio = db.Query<EntityEquipo>(
                            sql: sql,
                            param: p,
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

        
        }
}
