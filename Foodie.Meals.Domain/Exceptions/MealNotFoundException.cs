using Foodie.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Domain.Exceptions
{
    public sealed class MealNotFoundException : NotFoundException
    {
        public MealNotFoundException(int mealId) : base($"The meal with the indetifier {mealId} was not found.") { }
    }
}
