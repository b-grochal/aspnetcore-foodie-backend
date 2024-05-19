namespace Foodie.Orders.Application.Features.Contractors.Queries.GetContractorById
{
    public class GetContractorByIdQueryResponse
    {
        public int Id { get; set; }
        public int RestaurantId { get; private set; }
        public string Name { get; private set; }
        public int LocationId { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public int CityId { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
    }
}
