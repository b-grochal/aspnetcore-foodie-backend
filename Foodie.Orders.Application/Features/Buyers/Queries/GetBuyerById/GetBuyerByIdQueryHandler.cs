using Foodie.Common.Results;
using Foodie.Orders.Application.Contracts.Infrastructure.Database.SqlQueries.Buyers;
using Foodie.Orders.Application.Features.Buyers.Errors;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Features.Buyers.Queries.GetBuyerById
{
    public class GetBuyerByIdQueryHandler : IRequestHandler<GetBuyerByIdQuery, Result<GetBuyerByIdQueryResponse>>
    {
        private readonly IGetBuyerByIdSqlQuery _sqlQuery;

        public GetBuyerByIdQueryHandler(IGetBuyerByIdSqlQuery sqlQuery)
        {
            _sqlQuery = sqlQuery;
        }

        public async Task<Result<GetBuyerByIdQueryResponse>> Handle(GetBuyerByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _sqlQuery.ExecuteAsync(request);

            if (result is null)
                return Result.Failure<GetBuyerByIdQueryResponse>(BuyerErrors.BuyerNotFoundById(request.Id));

            return result;
        }
    }
}
