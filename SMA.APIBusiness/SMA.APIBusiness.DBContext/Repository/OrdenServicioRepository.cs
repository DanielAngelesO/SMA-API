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
                    var servicio = new List<EntityOrdenServicio>();
                    const string sql = "";
                    servicio = db.Query<EntityOrdenServicio>(
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

        public EntityBaseResponse InsertOrdenServicio(EntityOrdenServicio ordenServicio, EntityCliente cliente)
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_Insert_Cliente_OrdenServicio";
                    var p = new DynamicParameters();

                    p.Add(name: "@IDSOLICITUD", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add(name: "@RUC_CLIENTE", value: cliente.Ruc_Cliente, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@RAZON_SOCIAL", value: cliente.Razon_Social, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    p.Add(name: "@CORREO", value: cliente.Correo, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@TELEFONO", value: cliente.Telefeono, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@CONTACTO", value: cliente.Contacto, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@COD_SERVICIO", value: ordenServicio.Cod_Servicio , dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@FECHA_SOLICITUD", value: ordenServicio.Fecha_Solicitud, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add(name: "@FECHA_TENTATIVA", value: ordenServicio.Fecha_Tentativa, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@USUARIO_REGISTRO", value: ordenServicio.Usuario_Registro, dbType: DbType.String, direction: ParameterDirection.Input);


                    db.Query<EntityBaseResponse>(
                        sql,
                        param: p,
                        commandType: CommandType.StoredProcedure
                        ).FirstOrDefault();

                    int IdSolicitud = p.Get<int>("@IDPROYECTO");

                    if (IdSolicitud > 0)
                    {
                        response.Issuccess = true;
                        response.ErrorCode= "0000";
                        response.ErrorMessage = String.Empty;
                        response.Data = new
                        {
                            id = IdSolicitud,
                            nombre = cliente.Razon_Social
                        };
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
