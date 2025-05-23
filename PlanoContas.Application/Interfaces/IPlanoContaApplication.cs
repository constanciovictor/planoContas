using PlanoContas.Application.DTOs.PlanoContas.Request;
using PlanoContas.Application.DTOs.PlanoContas.Response;
using PlanoContas.Domain.Models.Base;

namespace PlanoContas.Application.Interfaces
{
    public interface IPlanoContaApplication
    {
        Task<ResponseBase> AdicionarAsync(CreatePlanoContasRequest planoContas);

        Task<ResponseBase<GetPlanoContasResponse>> ObterPorIdAsync(int id);

        Task<ResponseBase<IEnumerable<GetPlanoContasResponse>>> ObterTodosAsync();

        Task<ResponseBase> AtualizarAsync(PatchPlanoContasRequest request);

        Task<ResponseBase> RemoverAsync(int id);
    }
}
