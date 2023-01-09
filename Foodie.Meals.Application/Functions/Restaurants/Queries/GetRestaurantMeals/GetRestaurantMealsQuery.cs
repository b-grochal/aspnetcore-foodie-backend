using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurantMeals
{
    public class GetRestaurantMealsQuery : IRequest<GetRestaurantsMealsQueryResponse>
    {
        public int RestaurantId { get; }

        public GetRestaurantMealsQuery(int restaurantId)
        {
            this.RestaurantId = restaurantId;
        }
    }
}
