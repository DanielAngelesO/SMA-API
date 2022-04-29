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

        public EntityBaseResponse insert(EntityPlanProyecto plan)
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "US_Insertar_Plan_Proyecto";
                    var p = new DynamicParameters();

                    p.Add(name: "@COD_SOLICITUD", value: plan.Codigo_Solicitud, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@FECHA_INICIO", value: plan.Fecha_Inicio, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add(name: "@@FECHA_FIN", value: plan.Fecha_Fin, dbType: DbType.DateTime, direction: ParameterDirection.Input);
                    p.Add(name: "@DIAS_MONITOREO", value: plan.Dias_Monitoreo, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@CANTIDAD_ANALISTAS", value: plan.Cantidad_Analista, dbType: DbType.Int32, direction: ParameterDirection.Input);
                    p.Add(name: "@MONTO_VIATICOS", value: plan.Monto_Viaticos , dbType: DbType.Decimal, direction: ParameterDirection.Input);
                    p.Add(name: "@PRECIO_FINAL_SERVICIO", value: plan.Precio_Final_Servicio, dbType: DbType.Decimal, direction: ParameterDirection.Input);


                    db.Query<EntityBaseResponse>(
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
