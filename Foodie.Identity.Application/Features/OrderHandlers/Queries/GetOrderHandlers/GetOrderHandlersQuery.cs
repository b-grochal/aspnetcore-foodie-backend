using Foodie.Common.Application.Requests.Queries.Interfaces;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Identity.Application.Functions.OrderHandlers.Queries.GetOrderHandlers
{
    public class GetOrderHandlersQuery : PagedQuery, IRequest<Result<GetOrderHandlersQueryResponse>>
    {
        public string Email { get; set; }
    }
}
