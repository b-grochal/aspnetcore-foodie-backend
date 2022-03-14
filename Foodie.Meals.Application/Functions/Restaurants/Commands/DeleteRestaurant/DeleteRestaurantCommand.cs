using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Restaurants.Commands.DeleteRestaurant
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
