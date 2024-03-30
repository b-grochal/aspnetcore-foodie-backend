using Foodie.Common.Application.Requests.Queries.Abstractions;
using MediatR;

namespace Foodie.Orders.Application.Functions.Contractors.Queries.GetContractors
{
    public class GetContractorsQuery : PagedQuery, IRequest<GetContractorsQueryResponse>
    {
        public int? RestaurantId { get; set; }
        public int? LocationId { get; set; }
        public int? CityId { get; set; }
    }
}
