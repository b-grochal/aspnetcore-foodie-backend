namespace Foodie.Orders.Application.Features.Buyers.Queries.GetBuyerById
{
    public class GetBuyerByIdQueryResponse
    {
        public int Id { get; set; }
        public string UserId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
    }
}
