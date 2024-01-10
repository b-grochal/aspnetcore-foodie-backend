using Foodie.Common.Application.Responses;

namespace Foodie.Meals.Application.Functions.Categories.Queries.GetCategories
{
    public class GetCategoriesQueryResponse : PagedResponse<CategoryDto>
    {
        public string Name { get; set; }
    }

    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
