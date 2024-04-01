using AutoMapper;
using Foodie.Common.Results;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Meals.Queries.GetMeals
{
    public class GetMealsQueryHandler : IRequestHandler<GetMealsQuery, Result<GetMealsQueryResponse>>
    {
        private readonly IMealsRepository mealsRepository;
        private readonly IMapper mapper;

        public GetMealsQueryHandler(IMealsRepository mealsRepository, IMapper mapper)
        {
            this.mealsRepository = mealsRepository;
            this.mapper = mapper;
        }

        public async Task<Result<GetMealsQueryResponse>> Handle(GetMealsQuery request, CancellationToken cancellationToken)
        {
            var result = await mealsRepository.GetAllAsync(request.PageNumber, request.PageSize, request.RestaurantId, request.Name);

            return new GetMealsQueryResponse
            {
                TotalCount = result.TotalCount,
                PageSize = result.PageSize,
                Page = result.Page,
                TotalPages = result.TotalPages,
                Items = mapper.Map<IEnumerable<MealDto>>(result.Items),
                Name = request.Name,
                RestaurantId = request.RestaurantId
            };
        }
    }
}
