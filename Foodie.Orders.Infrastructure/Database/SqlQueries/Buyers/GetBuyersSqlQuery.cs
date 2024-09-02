using Dapper;
using Foodie.Common.Collections;
using Foodie.Common.Infrastructure.Database.Connections.Interfaces;
using Foodie.Orders.Application.Contracts.Infrastructure.Database.SqlQueries.Buyers;
using Foodie.Orders.Application.Contracts.Infrastructure.Queries.Orders;
using Foodie.Orders.Application.Features.Buyers.Queries.GetBuyers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Dapper.SqlBuilder;

namespace Foodie.Orders.Infrastructure.Database.SqlQueries.Buyers
{
    public class GetBuyersSqlQuery : IGetBuyersSqlQuery
    {
        private readonly IDbConnecionFactory _dbConnecionFactory;

        public GetBuyersSqlQuery(IDbConnecionFactory dbConnecionFactory)
        {
            _dbConnecionFactory = dbConnecionFactory;
        }

        public async Task<GetBuyersQueryResponse> ExecuteAsync(GetBuyersQuery query)
        {
            var selector = PrepareSqlQueryTemplate(query.PageNumber, query.PageSize, query.Email);

            using var dbConnection = _dbConnecionFactory.CreateConnection();

            dbConnection.Open();

            var buyers = await dbConnection.QueryAsync<BuyerQueryDto>(selector.RawSql, selector.Parameters);
            return MapSqlQueryResult(buyers, query.PageNumber, query.PageSize, query.Email);
        }

        private Template PrepareSqlQueryTemplate(int pageNumber, int pageSize, string buyerEmail)
        {
            var builder = new SqlBuilder();

            var selector = builder.AddTemplate("""
                select /**select**/ 
                from buyers b 
                /**where**/ 
                /**orderby**/ 
                offset @offset 
                rows fetch next @pageSize 
                rows only
                """, new { offset = (pageNumber - 1) * pageSize, pageSize });

            builder.Select("""
                b.Id as Id, 
                b.FirstName as FirstName, 
                b.LastName as LastName, 
                b.Email as Email
                """);

            builder.OrderBy("b.Id desc");

            if (buyerEmail != null)
                builder.Where("b.Email = @buyerEmail", new { buyerEmail });

            return selector;
        }

        private GetBuyersQueryResponse MapSqlQueryResult(IEnumerable<BuyerQueryDto> data, int pageNumber, int pageSize, string buyerEmail)
        {
            var buyers = PagedList<BuyerQueryDto>.Create(data, pageNumber, pageSize);

            return new GetBuyersQueryResponse
            {
                TotalCount = buyers.TotalCount,
                PageSize = buyers.PageSize,
                Page = buyers.Page,
                TotalPages = (int)Math.Ceiling(buyers.TotalCount / (double)buyers.PageSize),
                Items = buyers.Items.Select(x => new BuyerDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email
                }),
                Email = buyerEmail
            };
        }

        class BuyerQueryDto
        {
            public int Id { get; set; }
            public string FirstName { get; private set; }
            public string LastName { get; private set; }
            public string Email { get; private set; }
        }
    }
}
