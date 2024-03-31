using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommand : IRequest<DeleteRestaurantCommandResponse>
    {
        public int Id { get; set; }

        public DeleteRestaurantCommand(int id)
        {
            this.Id = id;
        }
    }
}
