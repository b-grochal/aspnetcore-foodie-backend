using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Results;
using Foodie.Meals.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Meals.Application.Features.Meals.Errors;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Meals.Commands.DeleteMeal
{
    public class DeleteMealCommandHandler : IRequestHandler<DeleteMealCommand, Result<DeleteMealCommandResponse>>
    {
        private readonly IMealsRepository _mealsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMealCommandHandler(IMealsRepository mealsRepository, IUnitOfWork unitOfWork)
        {
            _mealsRepository = mealsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<DeleteMealCommandResponse>> Handle(DeleteMealCommand request, CancellationToken cancellationToken)
        {
            var mealToDelete = await _mealsRepository.GetByIdAsync(request.Id);

            if (mealToDelete is null)
                return Result.Failure<DeleteMealCommandResponse>(MealsErrors.MealNotFoundById(request.Id));

            await _mealsRepository.DeleteAsync(mealToDelete);
            await _unitOfWork.CommitChangesAsync(request.User, cancellationToken);

            return new DeleteMealCommandResponse
            {
                Id = request.Id
            };
        }
    }
}
