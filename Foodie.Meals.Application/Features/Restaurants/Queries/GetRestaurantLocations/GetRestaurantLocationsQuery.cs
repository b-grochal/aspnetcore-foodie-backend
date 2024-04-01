using Foodie.Common.Results;
using MediatR;

namespace Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurantLocations
{
    public class GetRestaurantLocationsQuery : IRequest<Result<GetRestaurantLocationsQueryResponse>>
    {
        public int Id { get; }
        public int? CityId { get; }

        public GetRestaurantLocationsQuery(int id, int? cityId)
        {
            Id = id;
            CityId = cityId;
        }
    }
}
