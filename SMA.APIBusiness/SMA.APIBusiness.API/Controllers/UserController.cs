﻿using DBContext;
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
        /// GetListUser
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")] 
        [AllowAnonymous]
        [HttpGet]
        [Route("GetListUser")]
        public ActionResult Get()
        {
            var ret = _UserRepository.GetUsers();

            if (ret == null)
                return StatusCode(401);

            return Json(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Usuario"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("Validar")]
        public ActionResult ValidarUsuario(string Usuario, string Password)
        {
            var Response = _UserRepository.ValidarUsuario(Usuario, Password);

            if (Response == null)
                return StatusCode(401);

            return Json(Response);
        }

    }
}