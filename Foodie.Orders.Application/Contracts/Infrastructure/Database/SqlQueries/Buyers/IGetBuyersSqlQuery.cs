using Foodie.Orders.Application.Features.Buyers.Queries.GetBuyers;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Contracts.Infrastructure.Database.SqlQueries.Buyers
{
    public interface IGetBuyersSqlQuery
    {
        Task<GetBuyersQueryResponse> ExecuteAsync(GetBuyersQuery query);
    }
}
