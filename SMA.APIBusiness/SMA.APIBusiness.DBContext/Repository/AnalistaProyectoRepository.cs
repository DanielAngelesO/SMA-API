﻿using Dapper;
using DBEntity;
using SMA.APIBusiness.DBContext.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DBContext
{
    public class AnalistaProyectoRepository : BaseRepository, IAnalistaProyectoRepository
    {
        public EntityBaseResponse GetAnalistaProyectoRepository()
        {
            throw new NotImplementedException();
        }

        public EntityBaseResponse ObtenerAnalista(string Codigo_Analista)
        {
            throw new NotImplementedException();
        }

        public EntityBaseResponse Insert(List<EntityAnalistaProyecto> Analistas)
        {
            var response = new EntityBaseResponse();
            try
            {
                using (var db = GetSqlConnection())
                {
                    const string sql = "usp_Insertar_Analista_x_Proyecto";

                    foreach (var item in Analistas)
                    {
                        var p = new DynamicParameters();

                        p.Add(name: "@COD_SOLICTUD", value:item.Codigo_Solicitud, dbType: DbType.Int32, direction: ParameterDirection.Input);
                        p.Add(name: "@COD_ANALISTA", value: item.Codigo_Analista, dbType: DbType.String, direction: ParameterDirection.Input);
                        p.Add(name: "@CARGO", value: item.Cargo, dbType: DbType.String, direction: ParameterDirection.Input);
                        p.Add(name: "@TAREA_ASIGNADA", value: item.Tarea_Asignada, dbType: DbType.String, direction: ParameterDirection.Input);                        

                        db.Query<EntityAnalistaProyecto>(
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
    }
}