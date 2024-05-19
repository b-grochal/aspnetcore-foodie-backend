using Foodie.Common.Results;

namespace Foodie.Meals.Application.Features.Categories.Errors
{
    public static class CategoriesErrors
    {
        public static Error CategoryNotFoundById(int id) =>
            Error.NotFound("Categories.CategoryNotFoundById",
                $"The category with the identifier {id} was not found.");
    }
}
