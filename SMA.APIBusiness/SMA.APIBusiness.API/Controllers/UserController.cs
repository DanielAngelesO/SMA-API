using DBContext;
using DBEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NSwag.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Security;

namespace SMA.Business.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {

        /// <summary>
        /// Constructor
        /// </summary>
        protected readonly IUserRepository _UserRepository;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserRepository"></param>
        public UserController(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("Validar")]
        public async Task<ActionResult> ValidarUsuario(EntityLogin login)
        {
            var ret = _UserRepository.ValidarUsuario(login);

            if (ret.Issuccess)
            {
                var loginResponse = ret.Data as EntityLoginResponse;
                var UserId = loginResponse.Usuario;
                var UserPerfil = loginResponse.Perfil;

                var token = JsonConvert.DeserializeObject<AccessToken>(
                    await new Authentication().GenerateToken(UserPerfil, UserId)
                    ).access_token;

                loginResponse.Token = token;
                ret.Data = loginResponse;
            }


            return Json(ret);
        }

    }
}