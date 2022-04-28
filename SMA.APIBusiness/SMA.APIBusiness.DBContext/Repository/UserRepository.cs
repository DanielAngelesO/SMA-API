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
                const string sql = @"";

                returnEntity = db.Query<EntityUser>(sql,
                    commandType: CommandType.StoredProcedure).ToList();
            }
            return returnEntity;
        }

        public EntityBaseResponse ValidarUsuario(EntityLogin login)
        {
            var response = new EntityBaseResponse();

            try
            {
                using (var db = GetSqlConnection())
                {
                    var UsuarioResponse = new EntityLoginResponse();
                    const string sql = @"usp_ValidarUsuario";
                    var p = new DynamicParameters();
                    p.Add(name: "@Usuario", value: login.Usuario, dbType: DbType.String, direction: ParameterDirection.Input);
                    p.Add(name: "@Password", value: login.Password, dbType: DbType.String, direction: ParameterDirection.Input);


                    UsuarioResponse = db.Query<EntityLoginResponse>(
                        sql: sql,
                        param: p,
                        commandType: CommandType.StoredProcedure).FirstOrDefault();

                    if (UsuarioResponse != null)
                    {
                        response.Issuccess = true;
                        response.ErrorCode = "0000";
                        response.ErrorMessage = String.Empty;
                        response.Data = UsuarioResponse;

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
