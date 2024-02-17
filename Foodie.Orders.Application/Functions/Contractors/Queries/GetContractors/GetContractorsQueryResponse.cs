using Foodie.Common.Application.Responses;
using System.Collections.Generic;

namespace Foodie.Orders.Application.Functions.Contractors.Queries.GetContractors
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
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
    }
}
