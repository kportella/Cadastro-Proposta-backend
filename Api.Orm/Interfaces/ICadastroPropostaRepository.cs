using System.Collections.Generic;
using Api.Domain.Dtos;
using Api.Domain.Entities;

namespace Api.Orm.Interfaces
{
    public interface ICadastroPropostaRepository
    {
        IEnumerable<PropostaDtoCreate> GetAll();
        PropostaDtoCreate Get(CPFDto CPFDto);
        bool Add(PropostaDtoCreate obj);
        void Remove(PropostaDtoCreate obj);
        void Update(PropostaDtoCreate obj);
    }
}
