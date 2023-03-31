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
        public int Id { get; }
        public int? CityId { get; }

        public GetRestaurantLocationsQuery(int id, int? cityId)
        {
            this.Id = id;
            this.CityId = cityId;
        }
    }
}
