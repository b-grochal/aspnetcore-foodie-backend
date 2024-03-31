using Foodie.Common.Results;

namespace Foodie.Meals.Application.Features.Categories.Errors
{
    public static class CategoryErrors
    {
        public static Error CategoryNotFoundById(int id) =>
            Error.NotFound("Category.CategoryNotFoundById",
                $"The category with the identifier {id} was not found.");
    }
}
