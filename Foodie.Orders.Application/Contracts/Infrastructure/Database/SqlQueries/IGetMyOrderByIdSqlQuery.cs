using Foodie.Orders.Application.Features.Orders.Queries.GetCustomersOrderById;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Contracts.Infrastructure.Database.SqlQueries
{
    public interface IGetMyOrderByIdSqlQuery
    {
        Task<GetMyOrderByIdQueryResponse> ExecuteAsync(GetMyOrderByIdQuery query); 
    }
}
