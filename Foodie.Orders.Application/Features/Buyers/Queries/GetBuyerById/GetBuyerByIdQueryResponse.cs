namespace Foodie.Orders.Application.Features.Buyers.Queries.GetBuyerById
{
    public class GetBuyerByIdQueryResponse
    {
        public int Id { get; set; }
        public long CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
