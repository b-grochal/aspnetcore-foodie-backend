using Foodie.Common.Application.Responses;
using System.Collections.Generic;

namespace Foodie.Orders.Application.Functions.Buyers.Queries.GetBuyers
{
    public class GetBuyersQueryResponse : PagedResponse<BuyerDto>
    {
        public string Email { get; set; }
    }

    public class BuyerDto
    {
        public int Id { get; set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
    }
}
