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
            var sqlConsultarDescricao = "  SELECT DESCRICAO FROM TREINA_SITUACAO WHERE SITUACAO = @SITUACAO";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SITUACAO", new DbString { Value = situacao, IsAnsi = true, IsFixedLength = true, Length = 2 });
                return con.QueryFirstOrDefault<string>(sqlConsultarDescricao, parameters);
            }
        }

        public List<SituacaoDto> TodasDescricoes()
        {
            var sql = "SELECT SITUACAO, DESCRICAO FROM TREINA_SITUACAO";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                return con.Query<SituacaoDto>(sql).ToList();
            }
        }
    }
}
