using System;
using System.Net;
using Api.Orm.Interfaces;
using Api.Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Api.Service;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropostaController : Controller
    {
        private readonly ICadastroPropostaRepository _cadastroPropostaRepository;

        public PropostaController(ICadastroPropostaRepository cadastroPropostaRepository)
        {
            _cadastroPropostaRepository = cadastroPropostaRepository;
        }
        [Authorize]
        [HttpPost]
        public ActionResult Add([FromBody] PropostaDtoCreate propostaDtoCreate)
        {
            try
            {
                _cadastroPropostaRepository.Add(propostaDtoCreate);
                return Ok();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize]
        [HttpGet]
        public ActionResult Get([FromBody] CPFDto CPFDto)
        {
            try
            {
                PropostaDtoCreate propostaDtoCreate = _cadastroPropostaRepository.Get(CPFDto);
                return Ok(propostaDtoCreate);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

    }
}
