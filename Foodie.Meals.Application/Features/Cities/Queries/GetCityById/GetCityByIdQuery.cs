using MediatR;

namespace Foodie.Meals.Application.Functions.Cities.Queries.GetCityById
{
    public class GetCityByIdQuery : IRequest<GetCityByIdQueryResponse>
    {
        public int Id { get; }

        public GetCityByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
