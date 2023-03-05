using Foodie.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Functions.Buyers.Queries.GetBuyers
{
    public class GetBuyersQueryResponse : PagedResponse
    {
        public IEnumerable<BuyerDto> Buyers { get; set; }
        public string Email { get; set; }
    }

    public class BuyerDto
    {
        public int BuyerId { get; set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
    }
}
