using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Api.Service.Dtos;
using Api.Orm;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CEPController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public CEPController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> retornarEndereco([FromBody] CEPDto CEPDto)
        {
            ProvedorCEP provedor = new ProvedorCEP();
            var response = await provedor.BuscarCEP(_clientFactory, CEPDto.CEP);
            return Ok(response);

        }
    }
}
