using Foodie.Shared.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Cities.Queries.GetCities
{
    public class GetCitiesQuery : PagedQuery, IRequest<CitiesListResponse>
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
