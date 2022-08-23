using System;
namespace TaskMap1.Models
{
    abstract class ConnectDB : IDisposable
    {
        protected System.Data.SqlClient.SqlConnection _connection;
        public ConnectDB(String DataSource, String InitialCatalog)
        {
            _connection = new System.Data.SqlClient.SqlConnection($"Data source={DataSource};initial catalog={InitialCatalog};integrated security=SSPI;");
            _connection.Open();
        }
        public void Dispose() => _connection?.Dispose();
    }
}
