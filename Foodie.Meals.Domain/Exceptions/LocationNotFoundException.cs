using Foodie.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Domain.Exceptions
{
    public sealed class LocationNotFoundException : NotFoundException
    {
        public LocationNotFoundException(int locationId) : base($"The location with the indetifier {locationId} was not found.") { }
    }
}
