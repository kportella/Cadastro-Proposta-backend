using System;
using System.Net;
using Api.Domain.Dtos;
using Api.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalcularPropostaController : Controller
    {
        [Authorize]
        [HttpPost]
        public ActionResult CalcularProposta([FromBody] CalcularValorDto calcularValorDto)
        {
            try
            {
                double Vlr_Solicitado = CalcularPropostaService.CalcularValorSolicitado(calcularValorDto);
                return Ok(new
                {
                    Vlr_Solicitado = Vlr_Solicitado
                });
            }
            catch (ArgumentException e)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

    }
}
