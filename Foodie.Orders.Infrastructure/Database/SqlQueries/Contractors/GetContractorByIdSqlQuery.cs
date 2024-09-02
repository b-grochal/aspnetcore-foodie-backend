using Dapper;
using Foodie.Common.Infrastructure.Database.Connections.Interfaces;
using Foodie.Orders.Application.Contracts.Infrastructure.Database.SqlQueries.Contractors;
using Foodie.Orders.Application.Features.Contractors.Queries.GetContractorById;
using System.Threading.Tasks;
using static Dapper.SqlBuilder;

namespace Foodie.Orders.Infrastructure.Database.SqlQueries.Contractors
{
    public class GetContractorByIdSqlQuery : IGetContractorByIdSqlQuery
    {
        private readonly IDbConnecionFactory _dbConnecionFactory;

        public GetContractorByIdSqlQuery(IDbConnecionFactory dbConnecionFactory)
        {
            _dbConnecionFactory = dbConnecionFactory;
        }

        public async Task<GetContractorByIdQueryResponse> ExecuteAsync(GetContractorByIdQuery query)
        {
            var selector = PrepareSqlQueryTemplate(query.Id);

            using var connection = _dbConnecionFactory.CreateConnection();
            connection.Open();

            var sqlQueryResult = await connection.QueryFirstOrDefaultAsync<ContractorDetailsQueryDto>(selector.RawSql, selector.Parameters);
            return sqlQueryResult is null ? null : MapSqlQueryResult(sqlQueryResult);
        }
        private Template PrepareSqlQueryTemplate(int id)
        {
            var builder = new SqlBuilder();

            var selector = builder.AddTemplate("""
                select /**select**/ 
                from contractors c 
                /**where**/
                """);

            builder.Select("""
                c.Id as Id, 
                c.RestaurantId as RestaurantId, 
                c.Name as Name, 
                c.LocationId as LocationId, 
                c.Address as Address, 
                c.PhoneNumber as PhoneNumber, 
                c.Email as Email, 
                c.CityId as CityId, 
                c.City as City, 
                c.CountryId as CountryId,
                c.Country as Country
                """);

            builder.Where("c.Id = @id", new { id });

            return selector;
        }

        private GetContractorByIdQueryResponse MapSqlQueryResult(ContractorDetailsQueryDto data)
        {
            return new GetContractorByIdQueryResponse
            {
                Id = data.Id,
                RestaurantId = data.RestaurantId,
                Name = data.Name,
                LocationId = data.LocationId,
                Address = data.Address,
                PhoneNumber = data.PhoneNumber,
                Email = data.Email,
                CityId = data.CityId,
                City = data.City,
                CountryId = data.CountryId,
                Country = data.Country
            };
        }

        class ContractorDetailsQueryDto
        {
            public int Id { get; set; }
            public int RestaurantId { get; private set; }
            public string Name { get; private set; }
            public int LocationId { get; private set; }
            public string Address { get; private set; }
            public string PhoneNumber { get; private set; }
            public string Email { get; private set; }
            public int CityId { get; private set; }
            public string City { get; private set; }
            public int CountryId { get; private set; }
            public string Country { get; private set; }
        }
    }
}
