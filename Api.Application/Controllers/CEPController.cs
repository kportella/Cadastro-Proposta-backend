using System;
using System.IO;
using System.Net;
using Api.Domain.Dtos;
using Api.Orm;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CEPController : Controller
    {
        [Authorize]
        [HttpPost]
        public ActionResult retornarEndereco([FromBody] CEPDto CEPDto)
        {
            try
            {
                ProvedorCEP provedor = new ProvedorCEP();
                return Ok(provedor.BuscarCEP(CEPDto.CEP));
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
