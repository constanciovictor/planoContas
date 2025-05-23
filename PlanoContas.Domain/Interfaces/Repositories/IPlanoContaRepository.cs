namespace PlanoContas.Domain.Interfaces.Repositories
{
    public interface IPlanoContaRepository
    {
        Task<IEnumerable<PlanoContas.Domain.Models.PlanoContas>> ObterPlanoContasPorTipo(int tipoContaId);
    }
}
