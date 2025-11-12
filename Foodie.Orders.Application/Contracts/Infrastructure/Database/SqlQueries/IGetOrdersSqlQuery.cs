using Foodie.Orders.Application.Features.Orders.Queries.GetOrders;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Contracts.Infrastructure.Database.SqlQueries
{
    public interface IGetOrdersSqlQuery
    {
        Task<GetOrdersQueryResponse> ExecuteAsync(GetOrdersQuery query);
    }
}
