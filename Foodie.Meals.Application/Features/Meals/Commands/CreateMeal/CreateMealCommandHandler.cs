using AutoMapper;
using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Results;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Meals.Commands.CreateMeal
{
    public class CreateMealCommandHandler : IRequestHandler<CreateMealCommand, Result<CreateMealCommandResponse>>
    {
        private readonly IMealsRepository _mealsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateMealCommandHandler(IMealsRepository mealsRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mealsRepository = mealsRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<CreateMealCommandResponse>> Handle(CreateMealCommand request, CancellationToken cancellationToken)
        {
            var meal = _mapper.Map<Meal>(request);
            await _mealsRepository.CreateAsync(meal);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return _mapper.Map<CreateMealCommandResponse>(meal);
        }
    }
}
