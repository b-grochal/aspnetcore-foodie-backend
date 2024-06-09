using Foodie.Common.Application.Requests.Queries.Interfaces;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Meals.Application.Functions.Countries.Queries.GetCountries
{
    public class GetCountriesQuery : PagedQuery, IRequest<Result<GetCountriesQueryResponse>>
    {
        public string Name { get; set; }
    }
}
