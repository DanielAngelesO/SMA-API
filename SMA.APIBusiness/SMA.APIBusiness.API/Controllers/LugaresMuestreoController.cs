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
    [Route("api/LugaresMuestreo")]
    [ApiController]
    public class LugaresMuestreoController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly ILugaresMuestreoRepository _LugaresMuestreo;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="OrdenServicio"></param>
        public LugaresMuestreoController(ILugaresMuestreoRepository OrdenServicio)
        {
            _LugaresMuestreo = OrdenServicio;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lugares"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("insert")]
        public ActionResult Insert(List<EntityLugaresMuestreo> lugares)
        {
            var ret = _LugaresMuestreo.Insert(lugares);
            return Json(ret);
        }

    }
}
