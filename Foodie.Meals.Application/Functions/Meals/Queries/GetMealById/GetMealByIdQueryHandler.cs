using AutoMapper;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Meals.Queries.GetMealById
{
    public class GetMealByIdQueryHandler : IRequestHandler<GetMealByIdQuery, MealDetailsResponse>
    {
        private readonly IMealsRepository mealsRepository;
        private readonly IMapper mapper;

        public GetMealByIdQueryHandler(IMealsRepository mealsRepository, IMapper mapper)
        {
            this.mealsRepository = mealsRepository;
            this.mapper = mapper;
        }

        public async Task<MealDetailsResponse> Handle(GetMealByIdQuery request, CancellationToken cancellationToken)
        {
            var meal = await mealsRepository.GetByIdAsync(request.MealId);
            return mapper.Map<MealDetailsResponse>(meal);
        }
    }
}
