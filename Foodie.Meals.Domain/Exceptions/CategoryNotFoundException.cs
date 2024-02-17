using Foodie.Common.Exceptions;

namespace Foodie.Meals.Domain.Exceptions
{
    public sealed class CategoryNotFoundException : NotFoundException
    {
        public CategoryNotFoundException(int categoryId) : base($"The category with the indetifier {categoryId} was not found.") { }
    }
}
