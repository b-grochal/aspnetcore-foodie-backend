﻿using AutoMapper;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurantMeals
{
    public class GetRestaurantMealsQueryHandler : IRequestHandler<GetRestaurantMealsQuery, GetRestaurantsMealsQueryResponse>
    {
        private readonly IMealsRepository mealsRepository;
        private readonly IMapper mapper;

        public GetRestaurantMealsQueryHandler(IMealsRepository mealsRepository, IMapper mapper)
        {
            this.mealsRepository = mealsRepository;
            this.mapper = mapper;
        }

        public async Task<GetRestaurantsMealsQueryResponse> Handle(GetRestaurantMealsQuery request, CancellationToken cancellationToken)
        {
            var meals = await mealsRepository.GetAllAsync(request.RestaurantId);

            return new GetRestaurantsMealsQueryResponse
            {
                RestaurantMeals = mapper.Map<IEnumerable<RestaurantMealDto>>(meals)
            };   
             
        }
    }
}
