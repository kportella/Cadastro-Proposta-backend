using System.Collections.Generic;
using Api.Service.Dtos;

namespace Api.Orm.Interfaces
{
    public interface IConveniadaRepository
    {
        List<ConveniadaDto> GetAll();
    }
}
