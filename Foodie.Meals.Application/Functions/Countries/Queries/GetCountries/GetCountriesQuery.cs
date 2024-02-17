using Foodie.Common.Application.Queries;
using MediatR;

namespace Foodie.Meals.Application.Functions.Countries.Queries.GetCountries
{
    public class GetCountriesQuery : PagedQuery, IRequest<GetCountriesQueryResponse>
    {
        public string Name { get; set; }
    }
}
