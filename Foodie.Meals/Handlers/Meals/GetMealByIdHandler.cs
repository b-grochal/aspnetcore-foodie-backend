using AutoMapper;
using Foodie.Meals.Queries.Meals;
using Foodie.Meals.Repositories.Interfaces;
using Foodie.Meals.Responses.Meals;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Handlers.Meals
{
    public class GetMealByIdHandler : IRequestHandler<GetMealByIdQuery, MealResponse>
    {
        private readonly IMealsRepository mealsRepository;
        private readonly IMapper mapper;

        public GetMealByIdHandler(IMealsRepository mealsRepository, IMapper mapper)
        {
            this.mealsRepository = mealsRepository;
            this.mapper = mapper;
        }

        public async Task<MealResponse> Handle(GetMealByIdQuery request, CancellationToken cancellationToken)
        {
            var meal = await mealsRepository.GetMeal(request.MealId);
            return mapper.Map<MealResponse>(meal);
        }
    }
}
