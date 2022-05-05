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

namespace SMA.APIBusiness.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/OrdenServicio")]
    [ApiController]
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
        public ActionResult Listar()
        {
            var ret = _OrdenServicio.GetOrdenServicioList();
            return Json(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CodigoServicio"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("listarPorCodigo")]
        public ActionResult Listar(int CodigoServicio)
        {
            var ret = _OrdenServicio.GetOrdenServicioList(CodigoServicio);
            return Json(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="NombreCliente"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("listarPorCliente")]
        public ActionResult Listar(string NombreCliente)
        {
            var ret = _OrdenServicio.GetOrdenServicioList(NombreCliente);
            return Json(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CodigoServicio"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("ObtenerProyecto")]
        public ActionResult ObtenerProyecto(int CodigoServicio)
        {
            var ret = _OrdenServicio.ObtenerProyecto(CodigoServicio);
            return Json(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="servicio"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [Authorize]
        [HttpPost]
        [Route("insert")]
        public ActionResult Insert(EntityOrdenServicio servicio)
        {
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;

            var userid = claims.Where(p => p.Type == "client_codigo_usuario").FirstOrDefault()?.Value;
            var userperfil = claims.Where(p => p.Type == "client_Perfil").FirstOrDefault()?.Value;


            servicio.Usuario_Registro = userid;


            var ret = _OrdenServicio.InsertOrdenServicio(servicio); 
            return Json(ret);
        }

    }
}
