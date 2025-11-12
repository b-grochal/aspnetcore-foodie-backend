using Foodie.Common.Results;
using Foodie.Orders.Application.Contracts.Infrastructure.Database.SqlQueries;
using Foodie.Orders.Application.Features.Orders.Errors;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Features.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Result<GetOrderByIdQueryResponse>>
    {
        private readonly IGetOrderByIdSqlQuery _sqlQuery;

        public GetOrderByIdQueryHandler(IGetOrderByIdSqlQuery sqlQuery)
        {
            _sqlQuery = sqlQuery;
        }

        public async Task<Result<GetOrderByIdQueryResponse>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _sqlQuery.ExecuteAsync(request);

            if (result is null)
                return Result.Failure<GetOrderByIdQueryResponse>(OrderErrors.OrderNotFoundById(request.Id));

            return result;
        }
    }
}
