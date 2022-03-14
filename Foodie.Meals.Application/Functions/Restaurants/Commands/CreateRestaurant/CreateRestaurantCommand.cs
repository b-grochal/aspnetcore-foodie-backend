using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Restaurants.Commands.CreateRestaurant
{
    public class CreateRestaurantCommand : IRequest
    {
        public string Name { get; set; }
        public IReadOnlyCollection<int> CategoryIds { get; set; }
    }
}
