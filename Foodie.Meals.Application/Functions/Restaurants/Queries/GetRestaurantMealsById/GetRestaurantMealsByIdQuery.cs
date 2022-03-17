using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurantMealsById
{
    public class GetRestaurantMealsByIdQuery : IRequest<IEnumerable<RestaurantMealResponse>>
    {
        public int RestaurantId { get; }

        public GetRestaurantMealsByIdQuery(int restaurantId)
        {
            this.RestaurantId = restaurantId;
        }
    }
}
