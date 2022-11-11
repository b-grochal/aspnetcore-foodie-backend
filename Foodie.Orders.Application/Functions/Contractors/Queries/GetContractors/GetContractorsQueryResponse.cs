using Foodie.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Functions.Contractors.Queries.GetContractors
{
    public class GetContractorsQueryResponse : PagedResponse
    {
        public IEnumerable<ContractorDto> Contractors { get; set; }
        public int? RestaurantId { get; set; }
        public int? LocationId { get; set; }
        public int? CityId { get; set; }

    }
}
