using Microsoft.Data.SqlClient;
using PlanoContas.Domain.Interfaces.Repositories.DataConector;
using System.Data;

namespace PlanoContas.Infra.SqlDataBase
{
    public class SqlConnector : IDbConnector
    {
        public SqlConnector(string connectionString)
        {
            dbConnection = SqlClientFactory.Instance.CreateConnection();
            dbConnection.ConnectionString = connectionString;
        }

        public IDbConnection dbConnection { get; }

        public IDbTransaction dbTransaction { get; set; }

        public IDbTransaction BeginTransaction(IsolationLevel isolation)
        {
            if (dbTransaction != null)
            {
                return dbTransaction;
            }

            if (dbConnection.State == ConnectionState.Closed)
            {
                dbConnection.Open();
            }

            return (dbTransaction = dbConnection.BeginTransaction(isolation));
        }

        public void Dispose()
        {
            dbConnection?.Dispose();
            dbTransaction?.Dispose();
        }
    }
}
