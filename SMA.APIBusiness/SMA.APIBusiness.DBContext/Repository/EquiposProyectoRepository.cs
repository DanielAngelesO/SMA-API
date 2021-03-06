using Dapper;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DBContext
{
    public class EquiposProyectoRepository : BaseRepository, IEquiposProyectoRepository
    {
        public EntityBaseResponse GetEquiposProyecto(int Codigo_Solicitud)
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    var servicio = new List<EntityEquipoProyectoConsulta>();
                    const string sql = "usp_Consulta_Equipos_x_Serevicio";
                    var p = new DynamicParameters();

                    p.Add(name: "@COD_SOLICITUD", value: Codigo_Solicitud, dbType: DbType.String, direction: ParameterDirection.Input);

                    servicio = db.Query<EntityEquipoProyectoConsulta>(
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

        public EntityBaseResponse Insert(List<EntityEquiposProyecto> equipos)
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_Insertar_Equipos_Proyecto";

                    foreach (var item in equipos)
                    {
                        var p = new DynamicParameters();

                        p.Add(name: "@COD_SOLICTUD", value: item.Codigo_Solicitud, dbType: DbType.Int32, direction: ParameterDirection.Input);
                        p.Add(name: "@CODIGO_EQUIPO", value: item.Equipo, dbType: DbType.String, direction: ParameterDirection.Input);
                        p.Add(name: "@CANTIDAD", value: item.Cantidad, dbType: DbType.Int32, direction: ParameterDirection.Input);
                        p.Add(name: "@MATRIZ", value: item.Matriz, dbType: DbType.String, direction: ParameterDirection.Input);
                        p.Add(name: "@FECHA_SALIDA", value: item.Fecha_Salida, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                        p.Add(name: "@FECHA_RETORNO", value: item.Fecha_Retorno, dbType: DbType.DateTime, direction: ParameterDirection.Input);

                        db.Query<EntityEquiposProyecto>(
                            sql,
                            param: p,
                            commandType: CommandType.StoredProcedure
                            ).FirstOrDefault();
                    }

                    response.Issuccess = true;
                    response.ErrorCode = "0000";
                    response.ErrorMessage = String.Empty;
                    response.Data = new
                    {
                        CodeResponse = 0,
                        MessageResponse = ""
                    };

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

        public EntityBaseResponse ActualizarDevolucion(List<EntityEquiposProyecto> equipos)
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_Actualizar_Devolucion_Equipos";

                    foreach (var item in equipos)
                    {
                        var p = new DynamicParameters();

                        p.Add(name: "@COD_SOLICTUD", value: item.Codigo_Solicitud, dbType: DbType.Int32, direction: ParameterDirection.Input);
                        p.Add(name: "@CODIGO_EQUIPO", value: item.Equipo, dbType: DbType.String, direction: ParameterDirection.Input);

                        db.Query<EntityEquiposProyecto>(
                            sql,
                            param: p,
                            commandType: CommandType.StoredProcedure
                            ).FirstOrDefault();
                    }

                    response.Issuccess = true;
                    response.ErrorCode = "0000";
                    response.ErrorMessage = String.Empty;
                    response.Data = new
                    {
                        CodeResponse = 0,
                        MessageResponse = ""
                    };

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

        public EntityBaseResponse ActualizarAprobacionEquipos(string CodigoSolicitud)
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_Actualizar_Aprobacion_Equipo";

                    var p = new DynamicParameters();

                    p.Add(name: "@@COD_SOLICITUD", value: CodigoSolicitud, dbType: DbType.Int32, direction: ParameterDirection.Input);                    

                    db.Query<EntityEquiposProyecto>(
                        sql,
                        param: p,
                        commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    response.Issuccess = true;
                    response.ErrorCode = "0000";
                    response.ErrorMessage = String.Empty;
                    response.Data = new
                    {
                        CodeResponse = 0,
                        MessageResponse = ""
                    };

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
