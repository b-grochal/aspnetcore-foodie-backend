using Foodie.Meals.Commands.Meals;
using Foodie.Meals.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Handlers.Meals
{
    public class DeleteMealHandler : IRequestHandler<DeleteMealCommand>
    {
        private readonly IMealsRepository mealsRepository;

        public DeleteMealHandler(IMealsRepository mealsRepository)
        {
            this.mealsRepository = mealsRepository;
        }

        public async Task<Unit> Handle(DeleteMealCommand request, CancellationToken cancellationToken)
        {
            await mealsRepository.DeleteMeal(request.MealId);
            return new Unit();
        }
    }
}
