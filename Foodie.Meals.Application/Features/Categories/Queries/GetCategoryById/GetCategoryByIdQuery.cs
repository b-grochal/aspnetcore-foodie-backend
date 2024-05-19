using Foodie.Common.Results;
using MediatR;

namespace Foodie.Meals.Application.Features.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery : IRequest<Result<GetCategoryByIdQueryResponse>>
    {
        public int Id { get; }

        public GetCategoryByIdQuery(int id)
        {
            Id = id;
        }
    }
}
