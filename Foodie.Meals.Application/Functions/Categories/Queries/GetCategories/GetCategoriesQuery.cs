using Foodie.Common.Application.Queries;
using MediatR;

namespace Foodie.Meals.Application.Functions.Categories.Queries.GetCategories
{
    public class GetCategoriesQuery : PagedQuery, IRequest<GetCategoriesQueryResponse>
    {
        public string Name { get; set; }
    }
}
