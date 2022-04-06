using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Meals.Commands.DeleteMeal
{
    public class DeleteMealCommand : IRequest<DeleteMealCommandResponse>
    {
        public int MealId { get; set; }

        public DeleteMealCommand(int mealId)
        {
            this.MealId = mealId;
        }
    }
}
