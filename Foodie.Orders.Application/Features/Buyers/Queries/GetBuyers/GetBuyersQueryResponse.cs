using Foodie.Common.Application.Responses;

namespace Foodie.Orders.Application.Features.Buyers.Queries.GetBuyers
{
    public class GetBuyersQueryResponse : PagedResponse<BuyerDto>
    {
        public string Email { get; set; }
    }

    public class BuyerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
