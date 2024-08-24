using Foodie.Orders.Application.Features.Orders.Queries.GetCustomersOrders;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Contracts.Infrastructure.Database.SqlQueries
{
    public interface IGetMyOrdersSqlQuery
    {
        Task<GetMyOrdersQueryResponse> ExecuteAsync(GetMyOrdersQuery query);
    }
}
