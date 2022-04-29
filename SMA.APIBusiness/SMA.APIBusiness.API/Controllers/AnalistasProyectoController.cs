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
    [Route("api/AnalistaPoryecto")]
    [ApiController]
    public class AnalistasProyectoController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IAnalistaProyectoRepository _AnalistaProyecto;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AnalistaProyecto"></param>
        public AnalistasProyectoController(IAnalistaProyectoRepository AnalistaProyecto)
        {
            _AnalistaProyecto = AnalistaProyecto;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="analistas"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("insert")]
        public ActionResult Insert(List<EntityAnalistaProyecto> analistas)
        {
            var ret = _AnalistaProyecto.Insert(analistas);
            return Json(ret);
        }
    }
}
