using Foodie.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Domain.Exceptions
{
    public sealed class RestaurantNotFoundException : NotFoundException
    {
        public RestaurantNotFoundException(int restaurantId) : base($"The restaurant with the indetifier {restaurantId} was not found.") { }
    }
}
