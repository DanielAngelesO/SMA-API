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
            var ret = _planillaAnalistaRepository.GetAnalistas();
            return Json(ret);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Codigo_Analista"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("listarxcodigo")]
        public ActionResult Listarxcodigo(string Codigo_Analista)
        {
            var ret = _planillaAnalistaRepository.ValidarCeseAnalista(Codigo_Analista);
            return Json(ret);
        }


    }
}
