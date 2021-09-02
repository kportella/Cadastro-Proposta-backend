using Api.Service.Dtos;

namespace Api.Orm.Interfaces
{
    public interface ICalcularPropostaRepository
    {
        double CalcularValorSolicitado(CalcularValorDto calcularValorDto);
    }
}
