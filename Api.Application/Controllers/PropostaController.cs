using System;
using System.Net;
using Api.Orm.Interfaces;
using Api.Service.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MassTransit;
using System.Threading.Tasks;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropostaController : Controller
    {
        private readonly ICadastroPropostaRepository _cadastroPropostaRepository;
        private IBusControl _busControl;

        public PropostaController(ICadastroPropostaRepository cadastroPropostaRepository, IBusControl busControl)
        {
            _cadastroPropostaRepository = cadastroPropostaRepository;
            _busControl = busControl;
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] PropostaDtoCreate propostaDtoCreate)
        {
            try
            {
                await _busControl.Publish(propostaDtoCreate);
                var numeroProposta = _cadastroPropostaRepository.Add(propostaDtoCreate);
                return Ok(numeroProposta);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize]
        [HttpGet]
        [Route("{CPF}")]
        public ActionResult Get(string CPF)
        {
            try
            {
                PropostaDtoCreate propostaDtoCreate = _cadastroPropostaRepository.Get(CPF);
                return Ok(propostaDtoCreate);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
        [HttpGet]
        [Route("usuario/{usuario}")]
        public ActionResult GetAll(string usuario)
        {
            try
            {
                List<PropostaDtoCreate> listPropostaDtoCreate = _cadastroPropostaRepository.GetAll(usuario);
                return Ok(listPropostaDtoCreate);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

    }
}
