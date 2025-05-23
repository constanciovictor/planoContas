using PlanoContas.Application.DTOs.PlanoContas.Request;
using PlanoContas.Application.DTOs.PlanoContas.Response;
using PlanoContas.Domain.Models;

namespace PlanoContas.Application.Mapper
{
    public class PlanoContaMapper : IPlanoContaMapper
    {
        public PlanoContas.Domain.Models.PlanoContas ToCreatePlanoContasRequest(CreatePlanoContasRequest request)
        {
            var tipoConta = new TipoConta
            {
                Id = request.TipoContaId
            };

            return new Domain.Models.PlanoContas
            {
                Nome = request.Nome,
                AceitaLancamentos = request.AceitaLancamentos,
                TipoConta = tipoConta
            };
        }

        public PlanoContas.Domain.Models.PlanoContas ToPatchPlanoContasRequest(PatchPlanoContasRequest request)
        {
            return new Domain.Models.PlanoContas
            {
                Nome = request.Nome,
                AceitaLancamentos = request.AceitaLancamentos
            };
        }

        public IEnumerable<GetPlanoContasResponse> ToGetPlanoContasResponse(IEnumerable<PlanoContas.Domain.Models.PlanoContas> planoContas)
        {
            return planoContas.Select(x => new GetPlanoContasResponse 
            {
                Id = x.Id,
                Codigo = x.Codigo,
                Nome = x.Nome,
                Tipo = x.TipoConta.Nome,
                AceitaLancamentos = x.AceitaLancamentos,
                IdPai = x.IdPai
            });
        }
        public GetPlanoContasResponse ToGetPlanoContasResponse(PlanoContas.Domain.Models.PlanoContas planoConta)
        {
            return new GetPlanoContasResponse
            {
                Id = planoConta.Id,
                Codigo = planoConta.Codigo,
                Nome = planoConta.Nome,
                Tipo = planoConta.TipoConta.Nome,
                AceitaLancamentos = planoConta.AceitaLancamentos,
                IdPai = planoConta.IdPai
            };
        }
    }
}
