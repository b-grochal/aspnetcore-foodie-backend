using Foodie.Shared.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.OrderHandlers.Queries.GetOrderHandlers
{
    public class GetOrderHandlersQuery : PagedQuery, IRequest<GetOrderHandlersQueryResponse>
    {
        public string Email { get; set; }
    }
}
