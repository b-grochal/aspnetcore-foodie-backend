using Foodie.Shared.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurants
{
    public class GetRestaurantsQuery : PagedQuery, IRequest<GetRestaurantsQueryResponse>
    {
        public int? CategoryId { get; set; }
        public string Name { get; set; }
        public string CityName { get; set; }
    }
}
