using System;
using System.Data.SqlClient;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Orm.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Api.Orm
{
    public class CalcularPropostaRepository : ConnectorRepository, ICalcularPropostaRepository
    {
        public CalcularPropostaRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public double CalcularValorSolicitado(CalcularValorDto calcularValorDto)
        {

            string sql = "SELECT VALOR from TREINA_PARAMETRO WHERE PropostaParametros = 'JuroComposto'";

            using (var con = new SqlConnection(base.GetConnection()))
            {

                double taxaFixa = con.QueryFirstOrDefault<double>(sql);
                double taxaDeJuro = 0;

                taxaDeJuro = Math.Pow(taxaFixa, calcularValorDto.Prazo);
                return Math.Round((calcularValorDto.Vlr_Solicitado * taxaDeJuro), 2, MidpointRounding.AwayFromZero);
            }

        }
    }
}
