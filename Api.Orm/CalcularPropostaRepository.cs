using System;
using System.Data.SqlClient;
using Api.Domain.Dtos;
using Api.Orm.Interfaces;
using Api.Service;
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
                return CalcularValorSolicitadoService.CalcularValorSolicitado(calcularValorDto, taxaFixa);
            }

        }
    }
}
