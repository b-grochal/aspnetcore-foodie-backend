using AutoMapper;
using Foodie.Common.Results;
using Foodie.Meals.Application.Contracts.Infrastructure.Database.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurants
{
    public class GetRestaurantsQueryHandler : IRequestHandler<GetRestaurantsQuery, Result<GetRestaurantsQueryResponse>>
    {
        private readonly IRestaurantsRepository restaurantsRepository;
        private readonly IMapper mapper;

        public GetRestaurantsQueryHandler(IRestaurantsRepository restaurantsRepository, IMapper mapper)
        {
            this.restaurantsRepository = restaurantsRepository;
            this.mapper = mapper;
        }

        public async Task<Result<GetRestaurantsQueryResponse>> Handle(GetRestaurantsQuery request, CancellationToken cancellationToken)
        {
            var result = await restaurantsRepository.GetAllAsync(request.PageNumber, request.PageSize, request.CategoryId, request.Name, request.CityName);

            return new GetRestaurantsQueryResponse
            {
                TotalCount = result.TotalCount,
                PageSize = result.PageSize,
                Page = result.Page,
                TotalPages = result.TotalPages,
                Items = mapper.Map<IEnumerable<RestaurantDto>>(result.Items),
                Name = request.Name,
                CityName = request.CityName,
                CategoryId = request.CategoryId
            };
        }
    }
}
