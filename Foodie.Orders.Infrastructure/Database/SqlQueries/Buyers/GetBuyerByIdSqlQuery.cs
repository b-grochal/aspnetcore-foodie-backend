using Dapper;
using Foodie.Common.Infrastructure.Database.Connections.Interfaces;
using Foodie.Orders.Application.Contracts.Infrastructure.Database.SqlQueries.Buyers;
using Foodie.Orders.Application.Features.Buyers.Queries.GetBuyerById;
using System.Threading.Tasks;
using static Dapper.SqlBuilder;

namespace Foodie.Orders.Infrastructure.Database.SqlQueries.Buyers
{
    public class GetBuyerByIdSqlQuery : IGetBuyerByIdSqlQuery
    {
        private readonly IDbConnecionFactory _dbConnectionFactory;

        public GetBuyerByIdSqlQuery(IDbConnecionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<GetBuyerByIdQueryResponse> ExecuteAsync(GetBuyerByIdQuery query)
        {
            var selector = PrepareSqlQueryTemplate(query.Id);

            using var connection = _dbConnectionFactory.CreateConnection();
            connection.Open();

            var sqlQueryResult = await connection.QueryFirstOrDefaultAsync<BuyerDetailsQueryDto>(selector.RawSql, selector.Parameters);
            return sqlQueryResult is null ? null : MapSqlQueryResult(sqlQueryResult);
        }

        private Template PrepareSqlQueryTemplate(int orderId)
        {
            var builder = new SqlBuilder();

            var selector = builder.AddTemplate("""
                select /**select**/ 
                from buyers b 
                /**where**/
                """);

            builder.Select("""
                b.Id as Id, 
                b.CustomerId as CustomerId, 
                b.FirstName as FirstName, 
                b.LastName as LastName, 
                b.PhoneNumber as PhoneNumber, 
                b.Email as Email
                """);

            builder.Where("b.Id = @id", new { orderId });

            return selector;
        }

        private GetBuyerByIdQueryResponse MapSqlQueryResult(BuyerDetailsQueryDto data)
        {
            return new GetBuyerByIdQueryResponse
            {
                Id = data.Id,
                CustomerId = data.CustomerId,
                FirstName = data.FirstName,
                LastName = data.LastName,
                PhoneNumber = data.PhoneNumber,
                Email = data.Email
            };
        }

        class BuyerDetailsQueryDto
        {
            public int Id { get; set; }
            public long CustomerId { get; private set; }
            public string FirstName { get; private set; }
            public string LastName { get; private set; }
            public string PhoneNumber { get; private set; }
            public string Email { get; private set; }
        }
    }
}
