using Dapper;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DBContext
{
    public class ParametrosLugarMuestraRepository : BaseRepository, IParametrosLugarMuestraRepository
    {
        public EntityBaseResponse Insert(List<EntityParametrosLugarMuestra> parametros)
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_Insertar_Resultado_Medicion";

                    foreach (var item in parametros)
                    {
                        var p = new DynamicParameters();

                        p.Add(name: "@CODIGO_MUESTREO", value: item.Codigo_Lugar, dbType: DbType.Int32, direction: ParameterDirection.Input);
                        p.Add(name: "@TIPO_PARAMETRO", value: item.Tipo_Parametro, dbType: DbType.String, direction: ParameterDirection.Input);
                        p.Add(name: "@DESCRIPCION_PARAMETRO", value: item.Descripcion_Parametro, dbType: DbType.String, direction: ParameterDirection.Input);
                        p.Add(name: "@UNIDAD_MEDIDA", value: item.Unidad_Medida, dbType: DbType.String, direction: ParameterDirection.Input);
                        p.Add(name: "@RESULTADO_MEDICION", value: item.Resultado_Medicion, dbType: DbType.String, direction: ParameterDirection.Input);

                        db.Query<EntityParametrosLugarMuestra>(
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

        public EntityBaseResponse ListarPorServicio(int CodigoSolicitud)
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    var parametros = new List<EntityParametrosLugarMuestra>();
                    const string sql = "usp_Consulta_Parametros_x_Servicio";
                    var p = new DynamicParameters();

                    p.Add(name: "@COD_SOLICITUD", value: CodigoSolicitud, dbType: DbType.Int32, direction: ParameterDirection.Input);

                    parametros = db.Query<EntityParametrosLugarMuestra>(
                            sql: sql,
                            param: p,
                            commandType: CommandType.StoredProcedure
                        ).ToList();

                    if (parametros.Count > 0)
                    {
                        response.Issuccess = true;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = String.Empty;
                        response.Data = parametros;
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
