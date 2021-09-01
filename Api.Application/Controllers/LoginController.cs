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
    public class LoginController : Controller
    {
        private readonly IUsuarioLoginRepository _usuarioLoginRepository;

        public LoginController(IUsuarioLoginRepository usuarioLoginRepository)
        {
            _usuarioLoginRepository = usuarioLoginRepository;
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Authenticate([FromBody] LoginDto loginDto)
        {
            try
            {
                int flag = _usuarioLoginRepository.Login(loginDto);

                switch (flag)
                {
                    case 2:
                        {
                            return StatusCode(403, new { message = "Senha expirada" });
                        }
                    case 1:
                        {
                            var token = TokenService.GenerateToken(loginDto);
                            return Ok(new
                            {
                                token = token
                            });
                        }
                    default:
                        {
                            return NotFound(new { message = "Usuário/Senha não encontrado" });
                        }
                }
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
