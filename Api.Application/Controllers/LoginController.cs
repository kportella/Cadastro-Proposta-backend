using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Orm;
using Api.Orm.Interfaces;
using Api.Service;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IClienteLoginRepository _clienteLoginRepository;

        public LoginController(IClienteLoginRepository clienteLoginRepository)
        {
            _clienteLoginRepository = clienteLoginRepository;
        }

        [HttpPost]
        public ActionResult Authenticate([FromBody] LoginDto loginDto)
        {
            int flag = _clienteLoginRepository.Login(loginDto);

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
                            user = loginDto.Usuario,
                            token = token
                        });
                    }
                default:
                    {
                        return NotFound(new { message = "Usuário/Senha não encontrado" });
                    }
            }
        }
    }
}
