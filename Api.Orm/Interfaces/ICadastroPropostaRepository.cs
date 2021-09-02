using System.Collections.Generic;
using Api.Service.Dtos;
using Api.Domain.Entities;

namespace Api.Orm.Interfaces
{
    public interface ICadastroPropostaRepository
    {
        List<PropostaDtoCreate> GetAll(string usuario);
        PropostaDtoCreate Get(string CPF);
        int Add(PropostaDtoCreate obj);
        void Remove(PropostaDtoCreate obj);
        void Update(PropostaDtoCreate obj);
    }
}
