using Foodie.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Domain.Exceptions
{
    public sealed class CityNotFoundException : NotFoundException
    {
        public CityNotFoundException(int cityId) : base($"The city with the indetifier {cityId} was not found.") { }
    }
}
