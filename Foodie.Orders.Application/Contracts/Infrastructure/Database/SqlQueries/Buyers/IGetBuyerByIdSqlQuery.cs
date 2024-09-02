using Foodie.Orders.Application.Features.Buyers.Queries.GetBuyerById;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Contracts.Infrastructure.Database.SqlQueries.Buyers
{
    public interface IGetBuyerByIdSqlQuery
    {
        Task<GetBuyerByIdQueryResponse> ExecuteAsync(GetBuyerByIdQuery query);
    }
}
