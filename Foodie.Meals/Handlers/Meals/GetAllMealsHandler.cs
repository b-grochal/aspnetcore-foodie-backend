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
    public class GetAllMealsHandler : IRequestHandler<GetAllMealsQuery, IEnumerable<MealResponse>>
    {
        private readonly IMealsRepository mealsRepository;
        private readonly IMapper mapper;

        public GetAllMealsHandler(IMealsRepository mealsRepository, IMapper mapper)
        {
            this.mealsRepository = mealsRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<MealResponse>> Handle(GetAllMealsQuery request, CancellationToken cancellationToken)
        {
            var meals = await mealsRepository.GetMeals();
            return mapper.Map<IEnumerable<MealResponse>>(meals);
        }
    }
}
