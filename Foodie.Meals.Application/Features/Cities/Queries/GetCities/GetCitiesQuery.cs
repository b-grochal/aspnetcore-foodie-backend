using Foodie.Common.Application.Requests.Queries.Interfaces;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Meals.Application.Functions.Cities.Queries.GetCities
{
    public class GetCitiesQuery : PagedQuery, IRequest<Result<GetCitiesQueryResponse>>
    {
        public string Name { get; set; }
        public int? CountryId { get; set; }
    }
}
