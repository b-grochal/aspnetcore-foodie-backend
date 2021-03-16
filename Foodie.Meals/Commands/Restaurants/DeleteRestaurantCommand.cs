using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Meals.Commands.Restaurants
{
    public class DeleteRestaurantCommand : IRequest
    {
        public int RestaurantId { get; set; }

        public DeleteRestaurantCommand(int restaurantId)
        {
            this.RestaurantId = restaurantId;
        }
    }
}
