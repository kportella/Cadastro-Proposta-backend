using Api.Domain.Entities;

namespace Api.Service.Dtos
{
    public class PropostaDtoCreate
    {
        public TreinaClientesEntity TreinaClientesEntity { get; set; }
        public TreinaPropostasEntity TreinaPropostasEntity { get; set; }

    }
}
