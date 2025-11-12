using Foodie.Common.Results;
using Foodie.Orders.Application.Contracts.Infrastructure.Database.SqlQueries.Contractors;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Features.Contractors.Queries.GetContractors
{
    public class GetContractorsQueryHandler : IRequestHandler<GetContractorsQuery, Result<GetContractorsQueryResponse>>
    {
        private readonly IGetContractorsSqlQuery _sqlQuery;

        public GetContractorsQueryHandler(IGetContractorsSqlQuery sqlQuery)
        {
            _sqlQuery = sqlQuery;
        }

        public async Task<Result<GetContractorsQueryResponse>> Handle(GetContractorsQuery request, CancellationToken cancellationToken)
        {
            return await _sqlQuery.ExecuteAsync(request);
        }
    }
}
