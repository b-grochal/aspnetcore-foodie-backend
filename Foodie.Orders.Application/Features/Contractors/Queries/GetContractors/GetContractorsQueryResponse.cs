using Foodie.Common.Application.Responses;

namespace Foodie.Orders.Application.Features.Contractors.Queries.GetContractors
{
    public class GetContractorsQueryResponse : PagedResponse<ContractorDto>
    {
        public int? RestaurantId { get; set; }
        public int? LocationId { get; set; }
        public int? CityId { get; set; }
    }

    public class ContractorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
