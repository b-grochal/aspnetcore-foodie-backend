using Foodie.Common.Application.Queries;
using MediatR;

namespace Foodie.Orders.Application.Functions.Buyers.Queries.GetBuyers
{
    public class GetBuyersQuery : PagedQuery, IRequest<GetBuyersQueryResponse>
    {
        public string Email { get; set; }
    }
}
