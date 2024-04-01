using Foodie.Common.Results;

namespace Foodie.Meals.Application.Features.Meals.Errors
{
    public static class MealsErrors
    {
        public static Error MealNotFoundById(int id) =>
            Error.NotFound("Meals.MealNotFoundById",
                $"The meal with the identifier {id} was not found.");
    }
}
