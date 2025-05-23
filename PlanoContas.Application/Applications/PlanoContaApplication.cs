using PlanoContas.Application.DTOs.PlanoContas.Request;
using PlanoContas.Application.DTOs.PlanoContas.Response;
using PlanoContas.Application.Interfaces;
using PlanoContas.Application.Mapper;
using PlanoContas.Domain.Interfaces.Services;
using PlanoContas.Domain.Models.Base;

namespace PlanoContas.Application.Applications
{
    public class PlanoContaApplication : IPlanoContaApplication
    {
        private readonly IPlanoContaService _planoContaService;
        private readonly IPlanoContaMapper _mapper;

        public PlanoContaApplication(IPlanoContaService planoContaService, IPlanoContaMapper mapper)
        {
            _planoContaService = planoContaService;
            _mapper = mapper;
        }

        public async Task<ResponseBase<IEnumerable<GetPlanoContasResponse>>> ObterTodosAsync()
        {
            var response = await _planoContaService.ObterTodosAsync();
            return ResponseBase<GetPlanoContasResponse>.Success(_mapper.ToGetPlanoContasResponse(response.Data));
        }

        public async Task<ResponseBase<GetPlanoContasResponse>> ObterPorIdAsync(int id)
        {
            var response = new ResponseBase<GetPlanoContasResponse>();

            var planoConta = await _planoContaService.ObterPorIdAsync(id);

            if (planoConta.Errors.Any())
                return ResponseBase.Error<GetPlanoContasResponse>(planoConta.Errors);

            response.Data = _mapper.ToGetPlanoContasResponse(planoConta.Data);

            return response;
        }

        public async Task<ResponseBase> AdicionarAsync(CreatePlanoContasRequest request)
        {
            var planoConta = _mapper.ToCreatePlanoContasRequest(request);

            return await _planoContaService.AdicionarAsync(planoConta);
        }

        public async Task<ResponseBase> AtualizarAsync(PatchPlanoContasRequest request)
        {
            var planoConta = _mapper.ToPatchPlanoContasRequest(request);

            return await _planoContaService.AtualizarAsync(planoConta);
        }

        public async Task<ResponseBase> RemoverAsync(int id)
        {
            return await _planoContaService.RemoverAsync(id);
        }
    }
}
