using Dapper;
using Foodie.Common.Collections;
using Foodie.Common.Infrastructure.Database.Connections.Interfaces;
using Foodie.Orders.Application.Contracts.Infrastructure.Database.SqlQueries.Contractors;
using Foodie.Orders.Application.Features.Contractors.Queries.GetContractors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Dapper.SqlBuilder;

namespace Foodie.Orders.Infrastructure.Database.SqlQueries.Contractors
{
    public class GetContractorsSqlQuery : IGetContractorsSqlQuery
    {
        private readonly IDbConnecionFactory _dbConnecionFactory;

        public GetContractorsSqlQuery(IDbConnecionFactory dbConnecionFactory)
        {
            _dbConnecionFactory = dbConnecionFactory;
        }

        public async Task<GetContractorsQueryResponse> ExecuteAsync(GetContractorsQuery query)
        {
            var selector = PrepareSqlQueryTemplate(query.PageNumber, query.PageSize, query.RestaurantId, query.LocationId, query.CityId);

            using var connection = _dbConnecionFactory.CreateConnection();
            connection.Open();

            var contractors = await connection.QueryAsync<ContractorQueryDto>(selector.RawSql, selector.Parameters);
            return MapSqlQueryResult(contractors, query.PageNumber, query.PageSize, query.RestaurantId, query.LocationId, query.CityId);
        }

        private Template PrepareSqlQueryTemplate(int pageNumber, int pageSize, int? restaurantId, int? locationId, int? cityId)
        {
            var builder = new SqlBuilder();

            var selector = builder.AddTemplate("""
                select /**select**/ 
                from contractors c 
                /**where**/ 
                /**orderby**/ 
                offset @offset 
                rows fetch next @pageSize
                rows only
                """,
                new { offset = (pageNumber - 1) * pageSize, pageSize });

            builder.Select("""
                c.Id as Id, 
                c.Name as Name, 
                c.Address as Address, 
                c.City as City, 
                c.Country as Country
                """);

            builder.OrderBy("c.Id desc");

            if (restaurantId != null)
                builder.Where("c.RestaurantId = @restaurantId", new { restaurantId.Value });

            if (restaurantId != null)
                builder.Where("c.LocationId = @locationId", new { locationId.Value });

            if (restaurantId != null)
                builder.Where("c.CityId = @cityId", new { cityId.Value });

            return selector;
        }

        private GetContractorsQueryResponse MapSqlQueryResult(IEnumerable<ContractorQueryDto> data, int pageNumber, int pageSize, int? restaurantId, int? locationId, int? cityId)
        {
            var buyers = PagedList<ContractorQueryDto>.Create(data, pageNumber, pageSize);

            return new GetContractorsQueryResponse
            {
                TotalCount = buyers.TotalCount,
                PageSize = buyers.PageSize,
                Page = buyers.Page,
                TotalPages = (int)Math.Ceiling(buyers.TotalCount / (double)buyers.PageSize),
                Items = buyers.Items.Select(x => new ContractorDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    City = x.City,
                    Country = x.Country,
                }),
                RestaurantId = restaurantId,
                LocationId = locationId,
                CityId = cityId
            };
        }

        class ContractorQueryDto
        {
            public int Id { get; set; }
            public string Name { get; private set; }
            public string Address { get; private set; }
            public string City { get; private set; }
            public string Country { get; private set; }
        }
    }
}
