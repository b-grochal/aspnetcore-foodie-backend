using Foodie.Common.Application.Requests.Queries.Abstractions;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Orders.Application.Features.Buyers.Queries.GetBuyers
{
    public class GetBuyersQuery : PagedQuery, IRequest<Result<GetBuyersQueryResponse>>
    {
        public string Email { get; set; }
    }
}
