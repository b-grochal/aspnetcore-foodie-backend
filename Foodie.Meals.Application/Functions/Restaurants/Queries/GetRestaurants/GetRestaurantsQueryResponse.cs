using Foodie.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurants
{
    public class GetRestaurantsQueryResponse : PagedResponse
    {
        public IEnumerable<RestauranatDto> Restaurants{ get; set; }
        public int? CategoryId { get; set; }
        public string Name { get; set; }
        public string CityName { get; set; }
    }
}
