using AutoMapper;
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
    public class EditMealHandler : IRequestHandler<EditMealCommand>
    {
        private readonly IMealsRepository mealsRepository;
        private readonly IMapper mapper;

        public EditMealHandler(IMealsRepository mealsRepository, IMapper mapper)
        {
            this.mealsRepository = mealsRepository;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(EditMealCommand request, CancellationToken cancellationToken)
        {
            var meal = await mealsRepository.GetMeal(request.MealId);
            var editedMeal = mapper.Map(request, meal);
            await mealsRepository.EditMeal(editedMeal);
            return new Unit();
        }
    }
}
