using AutoMapper;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Meals.Commands.UpdateMeal
{
    public class UpdateMealCommandHandler : IRequestHandler<UpdateMealCommand>
    {
        private readonly IMealsRepository mealsRepository;
        private readonly IMapper mapper;

        public UpdateMealCommandHandler(IMealsRepository mealsRepository, IMapper mapper)
        {
            this.mealsRepository = mealsRepository;
            this.mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateMealCommand request, CancellationToken cancellationToken)
        {
            var meal = await mealsRepository.GetByIdAsync(request.MealId);
            var editedMeal = mapper.Map(request, meal);
            await mealsRepository.UpdateAsync(editedMeal);
            return new Unit();
        }
    }
}
