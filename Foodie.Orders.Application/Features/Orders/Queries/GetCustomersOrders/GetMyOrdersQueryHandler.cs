using Foodie.Common.Results;
using Foodie.Orders.Application.Contracts.Infrastructure.Database.SqlQueries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Features.Orders.Queries.GetCustomersOrders
{
    public class GetMyOrdersQueryHandler : IRequestHandler<GetMyOrdersQuery, Result<GetMyOrdersQueryResponse>>
    {
        private readonly IGetMyOrdersSqlQuery _sqlQuery;

        public GetMyOrdersQueryHandler(IGetMyOrdersSqlQuery sqlQuery)
        {
            _sqlQuery = sqlQuery;
        }

        public async Task<Result<GetMyOrdersQueryResponse>> Handle(GetMyOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _sqlQuery.ExecuteAsync(request);
        }
    }
}
