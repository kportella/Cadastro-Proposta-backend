using System;
using System.Net;
using Api.Orm.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SituacaoPropostaController : Controller
    {
        private readonly ISituacaoRepository _situacaoRepository;

        public SituacaoPropostaController(ISituacaoRepository situacaoRepository)
        {
            _situacaoRepository = situacaoRepository;
        }
        [Authorize]
        [HttpGet]
        [Route("{situacao}")]
        public ActionResult Get(string situacao)
        {
            try
            {
                return Ok(new
                {
                    Descricao = _situacaoRepository.ConsultarDescricao(situacao)
                });
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
        [Authorize]
        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                return Ok(_situacaoRepository.TodasDescricoes());
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
