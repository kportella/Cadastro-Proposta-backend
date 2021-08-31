using System.Data.SqlClient;
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
    }
}
