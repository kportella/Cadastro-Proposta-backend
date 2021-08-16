using System.Collections.Generic;
using Api.Domain.Dtos;

namespace Api.Orm.Interfaces
{
    public interface IConveniadaRepository
    {
        List<ConveniadaDto> GetAll();
    }
}
