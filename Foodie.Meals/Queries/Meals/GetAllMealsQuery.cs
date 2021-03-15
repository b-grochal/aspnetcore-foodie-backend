using Foodie.Meals.Responses.Meals;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Meals.Queries.Meals
{
    public class GetAllMealsQuery : IRequest<IEnumerable<MealResponse>>
    {
    }
}
