using AutoMapper;
using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Meals.Commands.UpdateMeal
{
    public class UpdateMealCommandHandler : IRequestHandler<UpdateMealCommand, UpdateMealCommandResponse>
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

        public async Task<UpdateMealCommandResponse> Handle(UpdateMealCommand request, CancellationToken cancellationToken)
        {
            var meal = await _mealsRepository.GetByIdAsync(request.Id);

            if (meal == null)
                throw new MealNotFoundException(request.Id);

            var editedMeal = _mapper.Map(request, meal);
            await _mealsRepository.UpdateAsync(editedMeal);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return _mapper.Map<UpdateMealCommandResponse>(editedMeal);
        }
    }
}
