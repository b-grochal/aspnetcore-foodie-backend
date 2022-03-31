using AutoMapper;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Meals.Queries.GetMeals
{
    public class GetMealsQueryHandler : IRequestHandler<GetMealsQuery, MealsListResponse>
    {
        private readonly IMealsRepository mealsRepository;
        private readonly IMapper mapper;

        public GetMealsQueryHandler(IMealsRepository mealsRepository, IMapper mapper)
        {
            this.mealsRepository = mealsRepository;
            this.mapper = mapper;
        }

        public async Task<MealsListResponse> Handle(GetMealsQuery request, CancellationToken cancellationToken)
        {
            var meals = await mealsRepository.GetAllAsync(request.PageNumber, request.PageSize, request.RestaurantId, request.Name);

            return new MealsListResponse
            {
                TotalCount = meals.TotalCount,
                PageSize = meals.PageSize,
                CurrentPage = meals.CurrentPage,
                TotalPages = (int)Math.Ceiling(meals.TotalCount / (double)meals.PageSize),
                Meals = mapper.Map<IEnumerable<MealResponse>>(meals),
                Name = request.Name,
                RestaurantId = request.RestaurantId.Value
            };
        }
    }
}
