using Foodie.Common.Results;
using MediatR;

namespace Foodie.Meals.Application.Functions.Meals.Queries.GetMealById
{
    public class GetMealByIdQuery : IRequest<Result<GetMealByIdQueryResponse>>
    {
        public int Id { get; }

        public GetMealByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
