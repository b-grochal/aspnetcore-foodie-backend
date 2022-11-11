using Foodie.Shared.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Functions.Buyers.Queries.GetBuyers
{
    public class GetBuyersQuery : PagedQuery, IRequest<GetBuyersQueryResponse>
    {
        public string Email { get; set; }
    }
}
