using Foodie.Common.Application.Contracts.Infrastructure.Database;
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
        private readonly IMealsRepository _mealsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMealCommandHandler(IMealsRepository mealsRepository, IUnitOfWork unitOfWork)
        {
            _mealsRepository = mealsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteMealCommandResponse> Handle(DeleteMealCommand request, CancellationToken cancellationToken)
        {
            var mealToDelete = await _mealsRepository.GetByIdAsync(request.Id);

            if (mealToDelete == null)
                throw new MealNotFoundException(request.Id);

            await _mealsRepository.DeleteAsync(mealToDelete);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new DeleteMealCommandResponse
            {
                Id = request.Id
            };
        }
    }
}
