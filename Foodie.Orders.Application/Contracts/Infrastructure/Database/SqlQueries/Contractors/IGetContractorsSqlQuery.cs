using Foodie.Orders.Application.Features.Contractors.Queries.GetContractors;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Contracts.Infrastructure.Database.SqlQueries.Contractors
{
    public interface IGetContractorsSqlQuery
    {
        Task<GetContractorsQueryResponse> ExecuteAsync(GetContractorsQuery query);
    }
}
