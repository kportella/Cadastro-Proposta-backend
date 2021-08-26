using System;
using Api.Domain.Dtos;

namespace Api.Service
{
    public static class CalcularValorSolicitadoService
    {
        public static double CalcularValorSolicitado(CalcularValorDto calcularValorDto, double taxaFixa)
        {
            double taxaDeJuro = 0;

            taxaDeJuro = Math.Pow(taxaFixa, calcularValorDto.Prazo);
            return Math.Round((calcularValorDto.Vlr_Solicitado * taxaDeJuro), 2, MidpointRounding.AwayFromZero);
        }

    }
}
