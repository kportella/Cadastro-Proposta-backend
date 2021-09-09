using System;
using System.Net;
using Api.Service.Dtos;
using Api.Orm.Interfaces;
using Api.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MassTransit;
using System.Threading.Tasks;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalcularPropostaController : Controller
    {

        private IBusControl _busControl;

        private readonly ICalcularPropostaRepository _calcularPropostaRepository;

        public CalcularPropostaController(ICalcularPropostaRepository calcularPropostaRepository, IBusControl busControl)
        {
            _calcularPropostaRepository = calcularPropostaRepository;
            _busControl = busControl;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> CalcularProposta([FromBody] CalcularValorDto calcularValorDto)
        {

            try
            {
                var Vlr_Solicitado = _calcularPropostaRepository.CalcularValorSolicitado(calcularValorDto);
                return Ok(new
                {
                    Vlr_Solicitado = Vlr_Solicitado
                });
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

    }
}
