using System.Data;

namespace PlanoContas.Domain.Interfaces.Repositories.DataConector
{
    public interface IDbConnector : IDisposable
    {
        IDbConnection dbConnection { get; }
        IDbTransaction dbTransaction { get; set; }

        IDbTransaction BeginTransaction(IsolationLevel isolation);
    }
}
