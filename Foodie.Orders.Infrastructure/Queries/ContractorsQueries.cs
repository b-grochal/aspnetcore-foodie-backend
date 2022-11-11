using Dapper;
using Foodie.Orders.Application.Contracts.Infrastructure.Queries.Contractors;
using Foodie.Orders.Infrastructure.Contexts;
using Foodie.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlBuilder;

namespace Foodie.Orders.Infrastructure.Queries
{
    public class ContractorsQueries : IContractorsQueries
    {
        private readonly DapperContext _dapperContext;

        public ContractorsQueries(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<PagedList<ContractorQueryDto>> GetAllAsync(int pageNumber, int pageSize, int? restaurantId, int? locationId, int? cityId)
        {
            var selector = PrepareSqlTemplateForGettingAllContractors(pageNumber, pageSize, restaurantId, locationId, cityId);

            using var connection = _dapperContext.CreateConnection();
            connection.Open();

            var contractors = await connection.QueryAsync<ContractorQueryDto>(selector.RawSql, selector.Parameters);
            return PagedList<ContractorQueryDto>.ToPagedList(contractors, pageNumber, pageSize);
        }

        public async Task<ContractorDetailsQueryDto> GetByIdAsync(int id)
        {
            var selector = PrepareSqlTemplateForGettingContractorById(id);

            using var connection = _dapperContext.CreateConnection();
            connection.Open();

            var sqlQueryResult = await connection.QueryAsync<ContractorDetailsQueryDto>(selector.RawSql, selector.Parameters);
            return sqlQueryResult.FirstOrDefault();
        }

        private Template PrepareSqlTemplateForGettingAllContractors(int pageNumber, int pageSize, int? restaurantId, int? locationId, int? cityId)
        {
            var builder = new SqlBuilder();

            var selector = builder.AddTemplate("Select /**select**/ from contractors c /**where**/ /**orderby**/ offset @offset rows fetch next @pageSize rows only", new { offset = (pageNumber - 1) * pageSize, pageSize });
            builder.Select("c.Id as ContractorId, c.Name as Name, c.Address as Address, c.City as City, c.Country as Country");
            builder.OrderBy("c.Id");

            if (restaurantId != null)
                builder.Where("c.RestaurantId = @restaurantId", new { restaurantId.Value });

            if (restaurantId != null)
                builder.Where("c.LocationId = @locationId", new { locationId.Value });

            if (restaurantId != null)
                builder.Where("c.CityId = @cityId", new { cityId.Value });

            return selector;
        }

        private Template PrepareSqlTemplateForGettingContractorById(int id)
        {
            var builder = new SqlBuilder();

            var selector = builder.AddTemplate("Select /**select**/ from contractors c /**where**/");
            builder.Select("c.Id as ContractorId, c.RestaurantId as RestaurantId, c.Name as Name, c.LocationId as LocationId, c.Address as Address, c.PhoneNumber as PhoneNumber, c.Email as Email, c.CityId as CityId, c.City as City, c.Country as Country");
            builder.Where("c.Id = @id", new { id });

            return selector;
        }
    }
}
