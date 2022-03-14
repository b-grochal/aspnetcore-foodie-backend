﻿using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Meals.Commands.DeleteMeal
{
    public class DeleteMealCommandHandler : IRequestHandler<DeleteMealCommand>
    {
        private readonly IMealsRepository mealsRepository;

        public DeleteMealCommandHandler(IMealsRepository mealsRepository)
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
