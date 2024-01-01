using MediatR;

namespace Foodie.Meals.Application.Functions.Locations.Queries.GetLocationById
{
    public class GetLocationByIdQuery : IRequest<GetLocationByIdQueryResponse>
    {
        public int Id { get; }

        public GetLocationByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
