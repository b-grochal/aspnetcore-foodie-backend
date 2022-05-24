using Foodie.Shared.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Customers.Queries.GetCustomers
{
    public class GetCustomersQuery : PagedQuery, IRequest<GetCustomersQueryResponse>
    {
        public string Email { get; set; }
    }
}
