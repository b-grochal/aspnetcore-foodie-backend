using Foodie.Common.Application.Requests.Queries.Abstractions;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Orders.Application.Features.Contractors.Queries.GetContractors
{
    public class GetContractorsQuery : PagedQuery, IRequest<Result<GetContractorsQueryResponse>>
    {
        public int? RestaurantId { get; set; }
        public int? LocationId { get; set; }
        public int? CityId { get; set; }
    }
}
