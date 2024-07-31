using AutoMapper;
using Foodie.Common.Results;
using Foodie.Orders.Application.Contracts.Infrastructure.Database.SqlQueries;
using Foodie.Orders.Application.Contracts.Infrastructure.Queries.Orders;
using Foodie.Orders.Application.Features.Orders.Errors;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Features.Orders.Queries.GetCustomersOrderById
{
    public class GetMyOrderByIdQueryHandler : IRequestHandler<GetMyOrderByIdQuery, Result<GetMyOrderByIdQueryResponse>>
    {
        private readonly IGetMyOrderByIdSqlQuery _sqlQuery;

        public GetMyOrderByIdQueryHandler(IOrdersReadServcie orderQueries, IMapper mapper, IGetMyOrderByIdSqlQuery sqlQuery)
        {
            _sqlQuery = sqlQuery;
        }

        public async Task<Result<GetMyOrderByIdQueryResponse>> Handle(GetMyOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _sqlQuery.ExecuteAsync(request);

            if (result is null)
                return Result.Failure<GetMyOrderByIdQueryResponse>(OrderErrors.CustomersOrderNotFoundById(request.Id, request.ApplicationUserId));

            return result;
        }
    }
}
