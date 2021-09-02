using System;
using System.Net;
using Api.Domain.Dtos;
using Api.Orm.Interfaces;
using Api.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalcularPropostaController : Controller
    {

        private readonly ICalcularPropostaRepository _calcularPropostaRepository;

        public CalcularPropostaController(ICalcularPropostaRepository calcularPropostaRepository)
        {
            _calcularPropostaRepository = calcularPropostaRepository;
        }

        [Authorize]
        [HttpPost]
        public ActionResult CalcularProposta([FromBody] CalcularValorDto calcularValorDto)
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
