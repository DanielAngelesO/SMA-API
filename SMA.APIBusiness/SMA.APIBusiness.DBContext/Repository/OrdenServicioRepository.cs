using Dapper;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DBContext
{
    public class OrdenServicioRepository: BaseRepository, IOrdenServicio
    {
        public EntityBaseResponse GetOrdenServicioList()
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

        public EntityBaseResponse GetOrdenServicioList(int CodigoServicio)
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    var servicio = new List<EntityOrdenServcioConsulta>();
                    const string sql = "usp_ListarOrdenesServicios_x_Codigo";
                    var p = new DynamicParameters();                    
                    p.Add(name: "@COD_SOLICITUD", value: CodigoServicio, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    servicio = db.Query<EntityOrdenServcioConsulta>(
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

        public EntityBaseResponse GetOrdenServicioList(string NombreCliente)
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    var servicio = new List<EntityOrdenServcioConsulta>();
                    const string sql = "usp_ListarOrdenesServicios_x_Cliente";
                    var p = new DynamicParameters();
                    p.Add(name: "@Cliente", value: NombreCliente, dbType: DbType.String, direction: ParameterDirection.Input);

                    servicio = db.Query<EntityOrdenServcioConsulta>(
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

        public EntityBaseResponse InsertOrdenServicio(EntityOrdenServicio ordenServicio)
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_Insert_Cliente_OrdenServicio";
                    var p = new DynamicParameters();

                    p.Add(name: "@IDSOLICITUD", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add(name: "@RUC_CLIENTE", value: ordenServicio.Cliente.Ruc_Cliente, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@RAZON_SOCIAL", value: ordenServicio.Cliente.Razon_Social, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@CORREO", value: ordenServicio.Cliente.Correo, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@TELEFONO", value: ordenServicio.Cliente.Telefeono, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@CONTACTO", value: ordenServicio.Cliente.Contacto, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@COD_SERVICIO", value: ordenServicio.Cod_Servicio , dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@FECHA_SOLICITUD", value: ordenServicio.Fecha_Solicitud, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add(name: "@FECHA_TENTATIVA", value: ordenServicio.Fecha_Tentativa, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add(name: "@USUARIO_REGISTRO", value: ordenServicio.Usuario_Registro, dbType: DbType.String, direction: ParameterDirection.Input);


                    db.Query<EntityBaseResponse>(
                        sql,
                        param: p,
                        commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    int IdSolicitud = p.Get<int>("@IDSOLICITUD");

                    if (IdSolicitud > 0)
                    {
                        var _LugaresMuestro = new LugaresMuestreoRepository();
                        var responseLugares = _LugaresMuestro.Insert(IdSolicitud, ordenServicio.LugaresMuestreo);

                        if (responseLugares.Issuccess)
                        {
                            response.Issuccess = true;
                            response.ErrorCode = "0000";
                            response.ErrorMessage = String.Empty;
                            response.Data = new
                            {
                                id = IdSolicitud,
                                nombre = ordenServicio.Cliente.Razon_Social
                            };
                        }
                        else
                        {
                            response.Issuccess = false;
                            response.ErrorCode = "0000";
                            response.ErrorMessage = "Se creo la orden de servicio, pero no se completo el registro de lugares de muestro";
                            response.Data = new
                            {
                                id = IdSolicitud,
                                nombre = ordenServicio.Cliente.Razon_Social
                            };
                        }
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

        public EntityBaseResponse ObtenerProyecto(int CodigoProyecto)
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    var proyecto = new EntityProyecto();
                    const string sql = "usp_ListarOrdenesServicios_x_Codigo";
                    var p = new DynamicParameters();
                    p.Add(name: "@COD_SOLICITUD", value: CodigoProyecto, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    proyecto = db.Query<EntityProyecto>(
                            sql: sql,
                            param: p,
                            commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    if (proyecto?.Codigo_Solicitud != null)
                    {
                        var _AnalistasProyecto = new AnalistaProyectoRepository();
                        var _EquipoProyecto = new EquiposProyectoRepository();
                        var _LugaresMuestreo = new LugaresMuestreoRepository();
                        proyecto.Analistas = _AnalistasProyecto.ObtenerAnalistas(CodigoProyecto)?.Data as List<EntityAnalistaProyectoConsulta>;
                        proyecto.Equipos = _EquipoProyecto.GetEquiposProyecto(CodigoProyecto)?.Data as List<EntityEquipoProyectoConsulta>;

                        response.Issuccess = true;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = String.Empty;
                        response.Data = proyecto;
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
