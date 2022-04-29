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
    [Route("api/EquiposProyecto")]
    [ApiController]
    public class EquiposProyectoController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IEquiposProyectoRepository _EquiposProyecto;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="equiposProyecto"></param>
        public EquiposProyectoController(IEquiposProyectoRepository equiposProyecto)
        {
            _EquiposProyecto = equiposProyecto;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="equipos"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("insert")]
        public ActionResult Insert(List<EntityEquiposProyecto> equipos)
        {
            var ret = _EquiposProyecto.Insert(equipos);
            return Json(ret);
        }
    }
}
