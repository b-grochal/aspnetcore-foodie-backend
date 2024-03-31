using Foodie.Common.Application.Requests.Queries.Abstractions;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Meals.Application.Features.Categories.Queries.GetCategories
{
    public class GetCategoriesQuery : PagedQuery, IRequest<Result<GetCategoriesQueryResponse>>
    {
        public string Name { get; set; }
    }
}
