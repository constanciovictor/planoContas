using FluentValidation;
using PlanoContas.Domain.Interfaces.Repositories;
using PlanoContas.Domain.Interfaces.Services;
using PlanoContas.Domain.Models.Base;
using System.Numerics;

namespace PlanoContas.Domain.Services
{
    public class PlanoContaService : IPlanoContaService
    {
        private readonly IPlanoContaRepository _planoContaRepository;
        private readonly IBaseRepository<PlanoContas.Domain.Models.PlanoContas> _basePlanoContaRepository;
        private readonly IValidator<PlanoContas.Domain.Models.PlanoContas> _validator;

        public PlanoContaService(IPlanoContaRepository planoContaRepository,
            IBaseRepository<PlanoContas.Domain.Models.PlanoContas> basePlanoContaRepository,
            IValidator<PlanoContas.Domain.Models.PlanoContas> validator)
        {
            _planoContaRepository = planoContaRepository;
            _basePlanoContaRepository = basePlanoContaRepository;
            _validator = validator;
        }
        public async Task<ResponseBase<IEnumerable<PlanoContas.Domain.Models.PlanoContas>>> ObterTodosAsync()
        {
            var planosContas = await _basePlanoContaRepository.GetAllAsync();
            return ResponseBase<PlanoContas.Domain.Models.PlanoContas>.Success(planosContas);
        }

        public async Task<ResponseBase<PlanoContas.Domain.Models.PlanoContas>> ObterPorIdAsync(int id)
        {
            var response = new ResponseBase<PlanoContas.Domain.Models.PlanoContas>();

            var planoContas = await _basePlanoContaRepository.GetByIdAsync(id);
            
            if (planoContas == null)
            {
                response.Errors.Add(ReportErrors.Create("Plano de contas não encontrado"));
                return response;
            }

            response.Data = planoContas;
            return response;
        }

        public async Task<ResponseBase> AdicionarAsync(PlanoContas.Domain.Models.PlanoContas request)
        {
            var response = new ResponseBase();

            var validationResult = await _validator.ValidateAsync(request);
            var errors = validationResult.GetErrors();

            if (errors.Errors.Any())
                return errors;

            var planoContas = await _planoContaRepository.ObterPlanoContasPorTipo(request.TipoConta.Id);

            if (planoContas.Any(p => p.Codigo == request.Codigo))
            {
                response.Errors.Add(ReportErrors.Create("Já existe um plano de contas com esse código."));
                return response;
            }

            var prefixoPai = PlanoContas.Domain.Models.PlanoContas.ObterPrefixoPai(request.Codigo);

            if (!string.IsNullOrEmpty(prefixoPai) && !planoContas.Any(p => p.Codigo == prefixoPai))
            {
                response.Errors.Add(ReportErrors.Create($"Não existe um plano de contas pai com o código '{prefixoPai}' para incluir este filho."));
                return response;
            }

            await _basePlanoContaRepository.AddAsync(request);
            return ResponseBase.Success("Plano de contas adicionado com sucesso");
        }

        public async Task<ResponseBase> AtualizarAsync(PlanoContas.Domain.Models.PlanoContas request)
        {
            var response = new ResponseBase();

            var validationResult = await _validator.ValidateAsync(request);
            var errors = validationResult.GetErrors();

            if (errors.Errors.Any())
                return errors;

            var planoContas = await _basePlanoContaRepository.GetByIdAsync(request.Id);
            if (planoContas == null)
            {
                response.Errors.Add(ReportErrors.Create("Plano de contas não encontrado"));
                return response;
            }

            planoContas.Nome = request.Nome;
            planoContas.AceitaLancamentos = request.AceitaLancamentos;

            await _basePlanoContaRepository.UpdateAsync(planoContas);
            return ResponseBase.Success("Plano de contas atualizado com sucesso");
        }

        public async Task<ResponseBase> RemoverAsync(int id)
        {
            var response = new ResponseBase();

            var planoContas = await _basePlanoContaRepository.GetByIdAsync(id);
            if (planoContas == null)
            {
                response.Errors.Add(ReportErrors.Create("Plano de contas não encontrado"));
                return response;
            }

            await _basePlanoContaRepository.DeleteAsync(id);
            return ResponseBase.Success("Plano de contas removido com sucesso");
        }
    }
}