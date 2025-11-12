using Foodie.Orders.Application.Features.Orders.Queries.GetOrderById;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Contracts.Infrastructure.Database.SqlQueries
{
    public interface IGetOrderByIdSqlQuery
    {
        Task<GetOrderByIdQueryResponse> ExecuteAsync(GetOrderByIdQuery query);
    }
}
