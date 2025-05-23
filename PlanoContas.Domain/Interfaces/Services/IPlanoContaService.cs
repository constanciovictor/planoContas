using PlanoContas.Domain.Models.Base;

namespace PlanoContas.Domain.Interfaces.Services
{
    public interface IPlanoContaService
    {
        Task<ResponseBase<IEnumerable<PlanoContas.Domain.Models.PlanoContas>>> ObterTodosAsync();

        Task<ResponseBase<PlanoContas.Domain.Models.PlanoContas>> ObterPorIdAsync(int id);

        Task<ResponseBase> AdicionarAsync(PlanoContas.Domain.Models.PlanoContas planoContas);

        Task<ResponseBase> AtualizarAsync(PlanoContas.Domain.Models.PlanoContas planoContas);

        Task<ResponseBase> RemoverAsync(int id);
    }
} 