using Foodie.Common.Application.Requests.Queries.Abstractions;
using MediatR;

namespace Foodie.Meals.Application.Functions.Cities.Queries.GetCities
{
    public class GetCitiesQuery : PagedQuery, IRequest<GetCitiesQueryResponse>
    {
        public string Name { get; set; }
        public int? CountryId { get; set; }
    }
}
