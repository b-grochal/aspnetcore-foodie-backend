using Foodie.Common.Application.Queries;
using MediatR;

namespace Foodie.Identity.Application.Functions.OrderHandlers.Queries.GetOrderHandlers
{
    public class GetOrderHandlersQuery : PagedQuery, IRequest<GetOrderHandlersQueryResponse>
    {
        public string Email { get; set; }
    }
}
