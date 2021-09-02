using System.Collections.Generic;
using Api.Service.Dtos;

namespace Api.Orm.Interfaces
{
    public interface ISituacaoRepository
    {
        string ConsultarDescricao(string situacao);

        List<SituacaoDto> TodasDescricoes();
    }
}
