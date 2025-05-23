using Dapper;
using PlanoContas.Domain.Interfaces.Repositories;
using PlanoContas.Domain.Interfaces.Repositories.DataConector;
using PlanoContas.Domain.Models;
using PlanoContas.Infra.Queries;

namespace PlanoContas.Infra.Repositories
{
    public class PlanoContaRepository : IBaseRepository<PlanoContas.Domain.Models.PlanoContas>, IPlanoContaRepository
    {
        private readonly IDbConnector _dbConnector;
        public PlanoContaRepository(IDbConnector dbConnector)
        {
            _dbConnector = dbConnector;
        }

        public async Task<PlanoContas.Domain.Models.PlanoContas> GetByIdAsync(int id)
        {
            var lookup = new Dictionary<int, PlanoContas.Domain.Models.PlanoContas>();

            await _dbConnector.dbConnection.QueryAsync<PlanoContas.Domain.Models.PlanoContas, TipoConta, PlanoContas.Domain.Models.PlanoContas>(
                PlanoContaRepositoryQueries.GetPlanoContaByIdAsyncQuery,
                (plano, tipoConta) =>
                {
                    if (!lookup.TryGetValue(plano.Id, out var planoEntry))
                    {
                        planoEntry = plano;
                        lookup.Add(plano.Id, planoEntry);
                    }

                    planoEntry.TipoConta = tipoConta;
                    return planoEntry;
                },
                new { Id = id },
                _dbConnector.dbTransaction,
                splitOn: "Id"
            );

            return lookup.Values.FirstOrDefault()!;
        }


        public async Task<IEnumerable<PlanoContas.Domain.Models.PlanoContas>> GetAllAsync()
        {
            var result = await _dbConnector.dbConnection.QueryAsync<PlanoContas.Domain.Models.PlanoContas, TipoConta, PlanoContas.Domain.Models.PlanoContas>(
                PlanoContaRepositoryQueries.GetPlanoContasQuery,
                (plano, tipo) =>
                {
                    if (tipo != null)
                    {
                        tipo.Nome = tipo.Nome ?? string.Empty; 
                        plano.TipoConta = tipo;
                    }
                    return plano;
                },
                transaction: _dbConnector.dbTransaction,
                splitOn: "TipoContaId"
            );

            return result;
        }

        public async Task AddAsync(PlanoContas.Domain.Models.PlanoContas planoConta)
        {
            await _dbConnector.dbConnection.ExecuteAsync(PlanoContaRepositoryQueries.PostPlanoContaQuery, new
            {
                Codigo = planoConta.Codigo!,
                Nome = planoConta.Nome!,
                TipoContaId = planoConta.TipoConta.Id,
                AceitaLancamentos = planoConta.AceitaLancamentos!,
                IdPai = planoConta.IdPai!
            }, _dbConnector.dbTransaction);
        }

        public async Task UpdateAsync(PlanoContas.Domain.Models.PlanoContas planoConta)
        {
            await _dbConnector.dbConnection.ExecuteAsync(PlanoContaRepositoryQueries.PatchPlanoContaQuery, new
            {
                Nome = planoConta.Nome!,
                AceitaLancamentos = planoConta.AceitaLancamentos!,
                Id = planoConta.Id!
            }, _dbConnector.dbTransaction);
        }

        public async Task DeleteAsync(int id)
        {
            await _dbConnector.dbConnection.ExecuteAsync(PlanoContaRepositoryQueries.DeletePlanoContaQuery, new { id }, _dbConnector.dbTransaction);
        }

        public async Task<IEnumerable<PlanoContas.Domain.Models.PlanoContas>> ObterPlanoContasPorTipo(int tipoContaId)
        {
            var result = await _dbConnector.dbConnection.QueryAsync<PlanoContas.Domain.Models.PlanoContas>(
                PlanoContaRepositoryQueries.ObterPlanoContasPorTipoQuery, new { TipoContaId = tipoContaId });

            return result;
        }
    }
} 