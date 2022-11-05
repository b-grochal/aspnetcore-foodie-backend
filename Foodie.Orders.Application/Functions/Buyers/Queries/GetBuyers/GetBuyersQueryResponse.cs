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
}
