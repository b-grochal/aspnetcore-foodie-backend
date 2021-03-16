using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Meals.Commands.Meals
{
    public class DeleteMealCommand : IRequest
    {
        public int MealId { get; set; }

        public DeleteMealCommand(int mealId)
        {
            this.MealId = mealId;
        }
    }
}
