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

        public EntityBaseResponse Insert(List<EntityLugaresMuestreo> muestreos)
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_Insertar_Lugares_Muestreo";                    

                    foreach (var item in muestreos)
                    {
                        var p = new DynamicParameters();

                        p.Add(name: "@COD_SOLICTUD", dbType: DbType.Int32, direction: ParameterDirection.Input);
                        p.Add(name: "@LUGAR_MUESTREO", value: item.Lugar_Muestreo, dbType: DbType.String, direction: ParameterDirection.Input);
                        p.Add(name: "@COORDENADA_LONGITUD", value: item.Coordenada_Lontigitud, dbType: DbType.Decimal, direction: ParameterDirection.Input);
                        p.Add(name: "@COORDENADA_LATITUD", value: item.Coordenada_Latitud, dbType: DbType.String, direction: ParameterDirection.Input);
                        p.Add(name: "@NOMBRE_PUNTO", value: item.Nombre_Punto, dbType: DbType.String, direction: ParameterDirection.Input);

                        db.Query<EntityLugaresMuestreo>(
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

        public EntityBaseResponse ListLugarProyecto(int Codigo_Cliente)
        {
            throw new NotImplementedException();
        }
    }
}
