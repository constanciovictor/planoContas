using PlanoContas.Application.DTOs.PlanoContas.Request;
using PlanoContas.Application.DTOs.PlanoContas.Response;

namespace PlanoContas.Application.Mapper
{
    public interface IPlanoContaMapper
    {
        PlanoContas.Domain.Models.PlanoContas ToCreatePlanoContasRequest(CreatePlanoContasRequest request);
        PlanoContas.Domain.Models.PlanoContas ToPatchPlanoContasRequest(PatchPlanoContasRequest request);
        IEnumerable<GetPlanoContasResponse> ToGetPlanoContasResponse(IEnumerable<PlanoContas.Domain.Models.PlanoContas> planoContas);
        GetPlanoContasResponse ToGetPlanoContasResponse(PlanoContas.Domain.Models.PlanoContas planoConta);
    }
}
