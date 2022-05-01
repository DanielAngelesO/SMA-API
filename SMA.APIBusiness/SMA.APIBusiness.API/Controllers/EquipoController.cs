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
    [Route("api/Equipo")]
    [ApiController]
    public class EquipoController : Controller
    {
        /// <summary>
        /// Constructor
        /// </summary>
        protected readonly IEquipoRepository _equipoRepository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="equipoRepository"></param>
        public EquipoController (IEquipoRepository equipoRepository)
        {
            _equipoRepository = equipoRepository;
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
            var ret = _equipoRepository.ListarEquipos();
            return Json(ret);
        }

        [Produces("application/json")]
        [AllowAnonymous]
        [HttpGet]
        [Route("listarxcodigo")]
        public ActionResult Listarxcodigo(string Codigo_Equipo)
        {
            var ret = _equipoRepository.ListarEquipos(Codigo_Equipo);
            return Json(ret);
        }


    }
}
