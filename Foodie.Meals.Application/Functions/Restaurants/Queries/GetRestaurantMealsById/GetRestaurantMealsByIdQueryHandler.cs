using AutoMapper;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurantMealsById
{
    public class GetRestaurantMealsByIdQueryHandler : IRequestHandler<GetRestaurantMealsByIdQuery, IEnumerable<RestaurantMealResponse>>
    {
        private readonly IMealsRepository mealsRepository;
        private readonly IMapper mapper;

        public GetRestaurantMealsByIdQueryHandler(IMealsRepository mealsRepository, IMapper mapper)
        {
            this.mealsRepository = mealsRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<RestaurantMealResponse>> Handle(GetRestaurantMealsByIdQuery request, CancellationToken cancellationToken)
        {
            var meals = await mealsRepository.GetMeals(request.RestaurantId);
            return mapper.Map<IEnumerable<RestaurantMealResponse>>(meals);
        }
    }
}
