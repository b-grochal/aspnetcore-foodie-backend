using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Meals.Queries.GetMealById
{
    public class GetMealByIdQuery : IRequest<MealDetailsResponse>
    {
        public int MealId { get; }

        public GetMealByIdQuery(int mealId)
        {
            this.MealId = mealId;
        }
    }
}
