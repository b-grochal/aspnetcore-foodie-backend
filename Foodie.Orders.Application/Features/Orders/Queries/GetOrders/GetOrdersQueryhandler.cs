using Foodie.Common.Results;
using Foodie.Orders.Application.Contracts.Infrastructure.Database.SqlQueries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Features.Orders.Queries.GetOrders
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, Result<GetOrdersQueryResponse>>
    {
        private readonly IGetOrdersSqlQuery _sqlQuery;

        public GetOrdersQueryHandler(IGetOrdersSqlQuery sqlQuery)
        {
            _sqlQuery = sqlQuery;
        }

        public async Task<Result<GetOrdersQueryResponse>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _sqlQuery.ExecuteAsync(request);
        }
    }
}
