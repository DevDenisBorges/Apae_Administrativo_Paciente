using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Apae_Administrativo_Excepcionais.Controllers
{
    [ApiController]
    [ApiVersion("0.1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class FuncionarioController : ControllerBase
    {

        /// <summary>
        /// Tenta criar Favorito Informações informadas
        /// </summary>
        /// <response code="200">Ok</response>
        [HttpPost]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
