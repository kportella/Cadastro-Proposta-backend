using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Api.Service.Teste
{
    [TestClass]
    public class TokenServiceTeste
    {
        [TestMethod]
        public void GenerateTokenSucesso()
        {

            var token = TokenService.GenerateToken(new Domain.Dtos.LoginDto { Usuario = "4002JOSE", Senha = "SENHAJ" });
            Assert.IsNotNull(token);


        }

    }
}
