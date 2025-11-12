using Foodie.Common.Results;
using Foodie.Orders.Application.Contracts.Infrastructure.Database.SqlQueries.Buyers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Features.Buyers.Queries.GetBuyers
{
    public class GetBuyersQueryHandler : IRequestHandler<GetBuyersQuery, Result<GetBuyersQueryResponse>>
    {
        private readonly IGetBuyersSqlQuery _sqlQuery;

        public GetBuyersQueryHandler(IGetBuyersSqlQuery sqlQuery)
        {
            _sqlQuery = sqlQuery;
        }

        public async Task<Result<GetBuyersQueryResponse>> Handle(GetBuyersQuery request, CancellationToken cancellationToken)
        {
            return await _sqlQuery.ExecuteAsync(request);
        }
    }
}
