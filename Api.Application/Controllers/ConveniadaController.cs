
using System;
using System.Collections.Generic;
using System.Net;
using Api.Service.Dtos;
using Api.Orm.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConveniadaController : Controller
    {
        private readonly IConveniadaRepository _conveniadaRepository;

        public ConveniadaController(IConveniadaRepository conveniadaRepository)
        {
            _conveniadaRepository = conveniadaRepository;
        }

        [Authorize]
        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                IEnumerable<ConveniadaDto> listConveniada = _conveniadaRepository.GetAll();
                return Ok(listConveniada);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
