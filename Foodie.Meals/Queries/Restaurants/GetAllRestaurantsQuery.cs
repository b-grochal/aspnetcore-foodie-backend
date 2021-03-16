using Foodie.Meals.Responses.Restaurants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Meals.Queries.Restaurants
{
    public class GetAllRestaurantsQuery : IRequest<IEnumerable<RestaurantResponse>>
    {
    }
}
