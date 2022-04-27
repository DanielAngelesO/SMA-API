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


        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("insert")]
        public ActionResult Insert(EntityOrdenServicio servicio, EntityCliente cliente)
        {
            var ret = _OrdenServicio.InsertOrdenServicio(servicio, cliente);
            return Json(ret);
        }

    }
}
