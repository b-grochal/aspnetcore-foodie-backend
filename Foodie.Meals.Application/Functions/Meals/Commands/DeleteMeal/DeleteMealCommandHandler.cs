using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Meals.Commands.DeleteMeal
{
    public class DeleteMealCommandHandler : IRequestHandler<DeleteMealCommand, DeleteMealCommandResponse>
    {
        private readonly IMealsRepository mealsRepository;

        public DeleteMealCommandHandler(IMealsRepository mealsRepository)
        {
            this.mealsRepository = mealsRepository;
        }

        public async Task<DeleteMealCommandResponse> Handle(DeleteMealCommand request, CancellationToken cancellationToken)
        {
            var mealToDelete = await mealsRepository.GetByIdAsync(request.Id);

            if (mealToDelete == null)
                throw new MealNotFoundException(request.Id);

            await mealsRepository.DeleteAsync(mealToDelete);
            return new DeleteMealCommandResponse
            {
                Id = request.Id
            };
        }
    }
}
