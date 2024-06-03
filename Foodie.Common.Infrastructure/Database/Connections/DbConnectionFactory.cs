using Foodie.Common.Infrastructure.Database.Connections.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Foodie.Common.Infrastructure.Database.Connections
{
    public class DbConnectionFactory : IDbConnecionFactory
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DbConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
            // TODO: Throw exception if connections string is null
            _connectionString = _configuration.GetConnectionString("DbConnection");
        }

        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
