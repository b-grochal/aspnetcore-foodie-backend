using Foodie.Orders.Application.Features.Contractors.Queries.GetContractorById;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Contracts.Infrastructure.Database.SqlQueries.Contractors
{
    public interface IGetContractorByIdSqlQuery
    {
        Task<GetContractorByIdQueryResponse> ExecuteAsync(GetContractorByIdQuery query);
    }
}
