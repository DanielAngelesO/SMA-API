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

namespace SMA.APIBusiness.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/Analista")]
    [ApiController]
    public class PlanillaAnalistaController : Controller
    {
        /// <summary>
        /// Constructor
        /// </summary>
        protected readonly IPlanillaAnalistaRepository _planillaAnalistaRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="planillaAnalistaRepository"></param>
        public PlanillaAnalistaController (IPlanillaAnalistaRepository planillaAnalistaRepository)
        {
            _planillaAnalistaRepository = planillaAnalistaRepository;

        }

        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("listar")]
        public ActionResult Listar()
        {
            var ret = _planillaAnalistaRepository.GetAnalistas();
            return Json(ret);
        }
        


    }
}
