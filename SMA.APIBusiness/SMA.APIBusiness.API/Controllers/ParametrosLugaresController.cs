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
    [Route("api/Parametros")]
    [ApiController]
    public class ParametrosLugaresController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IParametrosLugarMuestraRepository _parametrosLugarMuestraRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametrosLugarMuestra"></param>
        public ParametrosLugaresController(IParametrosLugarMuestraRepository parametrosLugarMuestra)
        {
            _parametrosLugarMuestraRepository = parametrosLugarMuestra;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CodigoSolicitud"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("ListarPorServicio")]
        public ActionResult ListarParametros(int CodigoSolicitud)
        {
            var ret = _parametrosLugarMuestraRepository.ListarPorServicio(CodigoSolicitud);
            return Json(ret);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parametros"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [AllowAnonymous]
        [HttpPost]
        [Route("insert")]
        public ActionResult Insert(List<EntityParametrosLugarMuestra> parametros)
        {
            var ret = _parametrosLugarMuestraRepository.Insert(parametros);
            return Json(ret);
        }
    }
}
