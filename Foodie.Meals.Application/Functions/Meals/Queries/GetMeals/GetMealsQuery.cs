﻿using Foodie.Common.Application.Requests.Queries.Abstractions;
using MediatR;

namespace Foodie.Meals.Application.Functions.Meals.Queries.GetMeals
{
    public class GetMealsQuery : PagedQuery, IRequest<GetMealsQueryResponse>
    {
        public int? RestaurantId { get; set; }
        public string Name { get; set; }
    }
}
