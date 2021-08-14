using System;
using System.Net;
using Api.Orm.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Api.Domain.Entities;

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

        [HttpPost]
        public ActionResult Add([FromBody] TreinaPropostasEntity treinaPropostasEntity)
        {
            try
            {
                _cadastroPropostaRepository.Add(treinaPropostasEntity);
                return Ok();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
