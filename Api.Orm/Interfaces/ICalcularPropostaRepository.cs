using Api.Domain.Dtos;

namespace Api.Orm.Interfaces
{
    public interface ICalcularPropostaRepository
    {
        double CalcularValorSolicitado(CalcularValorDto calcularValorDto);
    }
}
