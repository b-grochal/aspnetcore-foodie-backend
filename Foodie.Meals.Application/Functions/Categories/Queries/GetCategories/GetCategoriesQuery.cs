using Foodie.Common.Application.Requests.Queries.Abstractions;
using MediatR;

namespace Foodie.Meals.Application.Functions.Categories.Queries.GetCategories
{
    public class GetCategoriesQuery : PagedQuery, IRequest<GetCategoriesQueryResponse>
    {
        public string Name { get; set; }
    }
}
