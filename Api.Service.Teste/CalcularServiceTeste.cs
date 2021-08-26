using Microsoft.VisualStudio.TestTools.UnitTesting;
using Api.Service;
using Api.Domain.Dtos;

namespace serviceteste
{
    [TestClass]
    public class CalcularServiceTeste
    {
        [TestMethod]
        public void CalcularServiceSucesso()
        {
            double teste = CalcularValorSolicitadoService.CalcularValorSolicitado(new CalcularValorDto { Prazo = 10, Vlr_Solicitado = 1000 }, 1.01);

            Assert.AreEqual(teste, 1104.62);
        }
    }
}
