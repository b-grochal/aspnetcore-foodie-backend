using Dapper;
using Foodie.Common.Collections;
using Foodie.Common.Infrastructure.Database.Connections.Interfaces;
using Foodie.Orders.Application.Contracts.Infrastructure.Queries.Buyers;
using Foodie.Orders.Infrastructure.Database;
using System.Linq;
using System.Threading.Tasks;
using static Dapper.SqlBuilder;

namespace Foodie.Orders.Infrastructure.Queries
{
    public class BuyersQueries : IBuyersQueries
    {
        private readonly IDbConnecionFactory _dapperContext;

        public BuyersQueries(IDbConnecionFactory dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<PagedList<BuyerQueryDto>> GetAllAsync(int pageNumber, int pageSize, string buyerEmail)
        {
            var selector = PrepareSqlTemplateForGettingAllBuyers(pageNumber, pageSize, buyerEmail);

            using var connection = _dapperContext.CreateConnection();
            connection.Open();

            var buyers = await connection.QueryAsync<BuyerQueryDto>(selector.RawSql, selector.Parameters);
            return PagedList<BuyerQueryDto>.Create(buyers, pageNumber, pageSize);
        }

        public async Task<BuyerDetailsQueryDto> GetByIdAsync(int id)
        {
            var selector = PrepareSqlTemplateForGettingBuyerById(id);

            using var connection = _dapperContext.CreateConnection();
            connection.Open();

            var sqlQueryResult = await connection.QueryAsync<BuyerDetailsQueryDto>(selector.RawSql, selector.Parameters);
            return sqlQueryResult.FirstOrDefault();
        }

        private Template PrepareSqlTemplateForGettingAllBuyers(int pageNumber, int pageSize, string buyerEmail)
        {
            var builder = new SqlBuilder();

            var selector = builder.AddTemplate("Select /**select**/ from buyers b /**where**/ /**orderby**/ offset @offset rows fetch next @pageSize rows only", new { offset = (pageNumber - 1) * pageSize, pageSize });
            builder.Select("b.Id as BuyerId, b.FirstName as FirstName, b.LastName as LastName, b.Email as Email");
            builder.OrderBy("b.Id");

            if (buyerEmail != null)
                builder.Where("b.Email = @buyerEmail", new { buyerEmail });

            return selector;
        }

        private Template PrepareSqlTemplateForGettingBuyerById(int id)
        {
            var builder = new SqlBuilder();

            var selector = builder.AddTemplate("Select /**select**/ from buyers b /**where**/");
            builder.Select("b.Id as BuyerId, b.UserId as UserId, b.FirstName as FirstName, b.LastName as LastName, b.PhoneNumber as PhoneNumber, b.Email as Email");
            builder.Where("b.Id = @id", new { id });

            return selector;
        }
    }
}
