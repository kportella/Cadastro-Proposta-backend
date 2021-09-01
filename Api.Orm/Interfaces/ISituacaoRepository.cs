using System.Collections.Generic;
using Api.Domain.Dtos;

namespace Api.Orm.Interfaces
{
    public interface ISituacaoRepository
    {
        string ConsultarDescricao(string situacao);

        List<SituacaoDto> TodasDescricoes();
    }
}
