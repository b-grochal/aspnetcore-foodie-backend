using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurantLocations
{
    public class GetRestaurantLocationsQuery : IRequest<GetRestaurantLocationsQueryResponse>
    {
        public int RestaurantId { get; }
        public int? CityId { get; }

        public GetRestaurantLocationsQuery(int restaurantId, int? cityId)
        {
            this.RestaurantId = restaurantId;
            this.CityId = cityId;
        }
    }
}
