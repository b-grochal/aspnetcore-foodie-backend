using Foodie.Common.Application.Requests.Queries.Interfaces;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurants
{
    public class GetRestaurantsQuery : PagedQuery, IRequest<Result<GetRestaurantsQueryResponse>>
    {
        public int? CategoryId { get; set; }
        public string Name { get; set; }
        public string CityName { get; set; }
    }
}
