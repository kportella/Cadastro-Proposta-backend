using System;
using Xunit;
using Api.Service;
using Api.Service.Dtos;

namespace serviceteste
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(10, 1000, 1.01, 1104.62)]
        [InlineData(20, 1500, 1.01, 1830.29)]
        public void Test1(int prazo, double valorSolicitado, double taxaJuro, double valorTeste)
        {
            double teste = CalcularValorSolicitadoService.CalcularValorSolicitado(new CalcularValorDto { Prazo = prazo, Vlr_Solicitado = valorSolicitado }, taxaJuro);

            Assert.Equal(teste, valorTeste);
        }
    }
}
