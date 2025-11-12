namespace Foodie.Orders.Application.Features.Contractors.Queries.GetContractorById
{
    public class GetContractorByIdQueryResponse
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int CityId { get; set; }
        public string City { get; set; }
        public int CountryId { get; set; }
        public string Country { get; set; }
    }
}
