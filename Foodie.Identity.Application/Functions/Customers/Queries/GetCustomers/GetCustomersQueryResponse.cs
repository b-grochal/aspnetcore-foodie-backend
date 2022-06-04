using Foodie.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Customers.Queries.GetCustomers
{
    public class GetCustomersQueryResponse : PagedResponse
    {
        public IEnumerable<CustomerDto> Customers { get; set; }
        public string Email { get; set; }
    }
}
