using System;
using Api.Service.Dtos;

namespace Api.Service
{
    public static class CalcularValorSolicitadoService
    {
        public static double CalcularValorSolicitado(CalcularValorDto calcularValorDto, double taxaFixa)
        {
            var taxaDeJuro = Math.Pow(taxaFixa, calcularValorDto.Prazo);
            return Math.Round((calcularValorDto.Vlr_Solicitado * taxaDeJuro), 2, MidpointRounding.AwayFromZero);
        }

    }
}
