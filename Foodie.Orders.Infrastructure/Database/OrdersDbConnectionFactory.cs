using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Foodie.Orders.Infrastructure.Database
{
    public class OrdersDbConnectionFactory
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public OrdersDbConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DbConnection");
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
