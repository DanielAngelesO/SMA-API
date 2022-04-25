using Dapper;
using DBEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DBContext
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public List<EntityUser> GetUsers()
        {
            var returnEntity = new List<EntityUser>();
            using (var db = GetSqlConnection())
            {
                const string sql = @"usp_ObtenerDepartamentos";


                returnEntity = db.Query<EntityUser>(sql,
                    commandType: CommandType.StoredProcedure).ToList();
            }
            return returnEntity;
        }

        public EntityBaseResponse ValidarUsuario(string Usuario, string Password)
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    var ListUser = new List<EntityUser>();
                    const string sql = @"usp_ValidarUsuario";
                    var p = new DynamicParameters();
                    p.Add(name: "@Usuario", value: Usuario, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@Password", value: Password, dbType: DbType.String, direction: ParameterDirection.Input);


                    ListUser = db.Query<EntityUser>(
                        sql: sql,
                        param: p,
                        commandType: CommandType.StoredProcedure).ToList();

                    if (ListUser.Count > 0)
                    {
                        response.Issuccess = true;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = String.Empty;
                        response.Data = ListUser;

                    }
                    else
                    {
                        response.Issuccess = false;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = String.Empty;
                        response.Data = ListUser;
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
