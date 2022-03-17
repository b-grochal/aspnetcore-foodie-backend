using Foodie.Shared.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Meals.Queries.GetMeals
{
    public class GetMealsQuery : PagedQuery, IRequest<MealsListResponse>
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
    }
}
