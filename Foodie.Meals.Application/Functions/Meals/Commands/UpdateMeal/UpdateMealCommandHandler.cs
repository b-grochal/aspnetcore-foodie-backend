using AutoMapper;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Meals.Commands.UpdateMeal
{
    public class UpdateMealCommandHandler : IRequestHandler<UpdateMealCommand, UpdateMealCommandResponse>
    {
        private readonly IMealsRepository mealsRepository;
        private readonly IMapper mapper;

        public UpdateMealCommandHandler(IMealsRepository mealsRepository, IMapper mapper)
        {
            this.mealsRepository = mealsRepository;
            this.mapper = mapper;
        }

        public async Task<UpdateMealCommandResponse> Handle(UpdateMealCommand request, CancellationToken cancellationToken)
        {
            var meal = await mealsRepository.GetByIdAsync(request.Id);

            if (meal == null)
                throw new MealNotFoundException(request.Id);

            var editedMeal = mapper.Map(request, meal);
            await mealsRepository.UpdateAsync(editedMeal);
            return mapper.Map<UpdateMealCommandResponse>(editedMeal);
        }
    }
}
