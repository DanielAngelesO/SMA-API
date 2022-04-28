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

namespace SMA.APIBusiness.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/OrdenServicio")]
    public class OrdenServicioController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IOrdenServicio _OrdenServicio;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="OrdenServicio"></param>
        public OrdenServicioController(IOrdenServicio OrdenServicio)
        {
            _OrdenServicio = OrdenServicio;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>        
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("listar")]
        public ActionResult GetOrdenes()
        {
            var ret = _OrdenServicio.GetOrdenServicioList();

            return Json(ret);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="servicio"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("insert")]
        public ActionResult Insert(EntityOrdenServicio servicio)
        {
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;

            var userid = claims.Where(p => p.Type == "").FirstOrDefault()?.Value;
            var useidn = claims.Where(p => p.Type == "").FirstOrDefault()?.Value;

            servicio.Usuario_Registro = userid;


            var ret = _OrdenServicio.InsertOrdenServicio(servicio); 
            return Json(ret);
        }

    }
}
