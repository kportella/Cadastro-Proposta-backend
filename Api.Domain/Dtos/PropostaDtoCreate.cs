using Api.Domain.Entities;

namespace Api.Domain.Dtos
{
    public class PropostaDtoCreate
    {
        public TreinaClientesEntity TreinaClientesEntity { get; set; }
        public TreinaPropostasEntity TreinaPropostasEntity { get; set; }

    }
}
