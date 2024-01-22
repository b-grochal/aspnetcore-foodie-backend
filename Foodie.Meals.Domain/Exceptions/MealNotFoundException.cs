using Foodie.Common.Exceptions;

namespace Foodie.Meals.Domain.Exceptions
{
    public sealed class MealNotFoundException : NotFoundException
    {
        public MealNotFoundException(int mealId) : base($"The meal with the indetifier {mealId} was not found.") { }
    }
}
