using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Api.Domain.Dtos;
using Api.Orm.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Api.Orm
{
    public class ConveniadaRepository : ConnectorRepository, IConveniadaRepository
    {

        public ConveniadaRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public List<ConveniadaDto> GetAll()
        {
            string sql = "SELECT CONVENIADA, DESCRICAO FROM TREINA_CONVENIADAS";

            using (var con = new SqlConnection(base.GetConnection()))
            {
                List<ConveniadaDto> conveniadas = con.Query<ConveniadaDto>(sql).ToList();
                return conveniadas;
            }
        }
    }
}
