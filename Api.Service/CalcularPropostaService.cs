using System;
using Api.Domain.Dtos;
using Api.Domain.Entities;

namespace Api.Service
{
    public class CalcularPropostaService
    {
        public static bool VerificarIdade(TreinaClientesEntity treinaClientesEntity)
        {
            DateTime diaAtual = DateTime.Now;

            TimeSpan date = diaAtual - treinaClientesEntity.Dt_Nascimento;
            int totalAnos = date.Days;
            totalAnos = totalAnos / 365;

            if (totalAnos >= 18)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static double CalcularValorSolicitado(CalcularValorDto calcularValorDto)
        {
            double taxaFixa = 1.01;
            double taxaDeJuro = 0;

            taxaDeJuro = Math.Pow(taxaFixa, calcularValorDto.Prazo);
            return Math.Round((calcularValorDto.Vlr_Solicitado * taxaDeJuro), 2, MidpointRounding.AwayFromZero);

        }
    }
}
