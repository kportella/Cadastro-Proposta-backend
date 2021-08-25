using Microsoft.Extensions.Configuration;

namespace Api.Orm
{
    public class CPFRepository : ConnectorRepository
    {
        public CPFRepository(IConfiguration configuration) : base(configuration)
        {
        }


    }
}
