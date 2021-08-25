using Microsoft.Extensions.Configuration;
namespace Api.Orm
{
    public class ConnectorRepository
    {
        public IConfiguration _configuration { get; set; }

        public ConnectorRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            Dapper.SqlMapper.AddTypeMap(typeof(string), System.Data.DbType.AnsiString);
        }

        public string GetConnection()
        {
            return _configuration.GetSection("Connections").GetSection("ConnectionString").Value;
        }
    }
}
