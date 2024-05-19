using Foodie.Common.Results;
using MediatR;

namespace Foodie.Meals.Application.Functions.Countries.Queries.GetCountryById
{
    public class GetCountryByIdQuery : IRequest<Result<GetCountryByIdQueryResponse>>
    {
        public int Id { get; }

        public GetCountryByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
