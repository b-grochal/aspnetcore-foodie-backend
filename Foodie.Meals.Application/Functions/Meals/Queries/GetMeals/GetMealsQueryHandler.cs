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
    public class GetMealsQueryHandler : IRequestHandler<GetMealsQuery, GetMealsQueryResponse>
    {
        private readonly IMealsRepository mealsRepository;
        private readonly IMapper mapper;

        public GetMealsQueryHandler(IMealsRepository mealsRepository, IMapper mapper)
        {
            this.mealsRepository = mealsRepository;
            this.mapper = mapper;
        }

        public async Task<GetMealsQueryResponse> Handle(GetMealsQuery request, CancellationToken cancellationToken)
        {
            var result = await mealsRepository.GetAllAsync(request.PageNumber, request.PageSize, request.RestaurantId, request.Name);

            return new GetMealsQueryResponse
            {
                TotalCount = result.TotalCount,
                PageSize = request.PageSize,
                CurrentPage = request.PageNumber,
                TotalPages = (int)Math.Ceiling(result.TotalCount / (double)request.PageSize),
                Meals = mapper.Map<IEnumerable<MealDto>>(result.Items),
                Name = request.Name,
                RestaurantId = request.RestaurantId
            };
        }
    }
}
