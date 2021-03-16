using AutoMapper;
using Foodie.Meals.Commands.Meals;
using Foodie.Meals.Models;
using Foodie.Meals.Repositories.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Handlers.Meals
{
    public class CreateMealHandler : IRequestHandler<CreateMealCommand>
    {
        private readonly IMealsRepository mealsRepository;
        private readonly IMapper mapper;

        public CreateMealHandler(IMealsRepository mealsRepository, IMapper mapper)
        {
            this.mealsRepository = mealsRepository;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(CreateMealCommand request, CancellationToken cancellationToken)
        {
            var meal = mapper.Map<Meal>(request);
            await mealsRepository.CreateMeal(meal);
            return new Unit();
        }
    }
}
