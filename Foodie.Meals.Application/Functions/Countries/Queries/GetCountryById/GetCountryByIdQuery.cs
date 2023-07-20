using MediatR;

namespace Foodie.Meals.Application.Functions.Countries.Queries.GetCountryById
{
    public class GetCountryByIdQuery : IRequest<GetCountryByIdQueryResponse>
    {
        public int Id { get; }

        public GetCountryByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
