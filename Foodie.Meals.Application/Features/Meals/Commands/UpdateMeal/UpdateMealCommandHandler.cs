using AutoMapper;
using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Results;
using Foodie.Meals.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Meals.Application.Features.Meals.Errors;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Meals.Commands.UpdateMeal
{
    public class UpdateMealCommandHandler : IRequestHandler<UpdateMealCommand, Result<UpdateMealCommandResponse>>
    {
        private readonly IMealsRepository _mealsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateMealCommandHandler(IMealsRepository mealsRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mealsRepository = mealsRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<UpdateMealCommandResponse>> Handle(UpdateMealCommand request, CancellationToken cancellationToken)
        {
            var meal = await _mealsRepository.GetByIdAsync(request.Id);

            if (meal is null)
                return Result.Failure<UpdateMealCommandResponse>(MealsErrors.MealNotFoundById(request.Id));

            var editedMeal = _mapper.Map(request, meal);
            await _mealsRepository.UpdateAsync(editedMeal);
            await _unitOfWork.CommitChangesAsync(request.User, cancellationToken);
            return _mapper.Map<UpdateMealCommandResponse>(editedMeal);
        }
    }
}
