using Foodie.Common.Results;
using Foodie.Orders.Application.Contracts.Infrastructure.Database.SqlQueries.Contractors;
using Foodie.Orders.Application.Features.Contractors.Errors;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Features.Contractors.Queries.GetContractorById
{
    public class GetContractorByIdQueryHandler : IRequestHandler<GetContractorByIdQuery, Result<GetContractorByIdQueryResponse>>
    {
        private readonly IGetContractorByIdSqlQuery _sqlQuery;

        public GetContractorByIdQueryHandler(IGetContractorByIdSqlQuery sqlQuery)
        {
            _sqlQuery = sqlQuery;
        }

        public async Task<Result<GetContractorByIdQueryResponse>> Handle(GetContractorByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _sqlQuery.ExecuteAsync(request);

            if (result is null)
                return Result.Failure<GetContractorByIdQueryResponse>(ContractorErrors.ContractorNotFoundById(request.Id));

            return result;
        }
    }
}
