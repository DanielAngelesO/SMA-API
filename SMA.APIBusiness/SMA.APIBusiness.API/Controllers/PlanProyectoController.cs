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
    [Route("api/PlanProyecto")]
    [ApiController]
    public class PlanProyectoController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IPlanProyectoRepository  _planProyecto;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="planProyecto"></param>
        public PlanProyectoController(IPlanProyectoRepository planProyecto)
        {
            _planProyecto = planProyecto;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="planProyecto"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("insert")]
        public ActionResult Insert(EntityPlanProyecto planProyecto)
        {            

            var ret = _planProyecto.insert(planProyecto);
            return Json(ret);
        }
    }
}
