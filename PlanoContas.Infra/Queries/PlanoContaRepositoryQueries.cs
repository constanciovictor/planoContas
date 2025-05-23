using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanoContas.Infra.Queries
{
    public static class PlanoContaRepositoryQueries
    {
        public const string GetPlanoContasQuery = @"
                 SELECT 
                     pc.Id,
                     pc.Nome,
                     pc.Codigo,
                     pc.AceitaLancamentos,
                     pc.IdPai,
                     pc.TipoContaId,
                     tc.Nome
                 FROM 
                     PlanoContas pc
                 LEFT JOIN 
                     TipoConta tc ON pc.TipoContaId = tc.Id;";

        public const string GetPlanoContaByIdAsyncQuery = @"
                SELECT 
                    pc.Id, pc.Nome, pc.Codigo, pc.AceitaLancamentos, pc.IdPai,
                    tc.Id, tc.Nome
                FROM PlanoContas pc
                INNER JOIN TipoConta tc on pc.TipoContaId = tc.Id
                WHERE pc.Id = @Id";

        public const string PostPlanoContaQuery = @"
                SELECT 
                    pc.Id, pc.Nome, pc.Codigo, pc.AceitaLancamentos, pc.IdPai,
                    tc.Id, tc.Nome
                FROM PlanoContas pc
                INNER JOIN TipoConta tc ON tc.Id = pc.IdPai
                WHERE pc.Id = @Id";

        public const string DeletePlanoContaQuery = @"
                DELETE FROM PlanoContas WHERE Id = @id";

        public const string ObterPlanoContasPorTipoQuery = @"
                SELECT
                   [Id]
                  ,[Codigo]
                  ,[Nome]
                  ,[TipoContaId]
                  ,[AceitaLancamentos]
                  ,[IdPai]
              FROM PlanoContas
              WHERE TipoContaId = @tipoContaId";

        public const string PatchPlanoContaQuery = @"
                UPDATE PlanoContas 
                SET 
                    Nome = @Nome,
                    AceitaLancamentos = @AceitaLancamentos
                WHERE Id = @Id";
    }
}
