using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Api.Domain.Dtos;
using Api.Orm.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Api.Orm
{
    public class SituacaoRepository : ConnectorRepository, ISituacaoRepository
    {
        public SituacaoRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public string ConsultarDescricao(string situacao)
        {
            string sqlConsultarDescricao = "  SELECT DESCRICAO FROM TREINA_SITUACAO WHERE SITUACAO = @SITUACAO";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SITUACAO", situacao);
                return con.QueryFirstOrDefault<string>(sqlConsultarDescricao, parameters);
            }
        }

        public List<SituacaoDto> TodasDescricoes()
        {
            string sql = "SELECT SITUACAO, DESCRICAO FROM TREINA_SITUACAO";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                return con.Query<SituacaoDto>(sql).ToList();
            }
        }
    }
}
