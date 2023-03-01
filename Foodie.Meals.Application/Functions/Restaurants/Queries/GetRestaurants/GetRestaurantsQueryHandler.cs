using AutoMapper;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurants
{
    public class GetRestaurantsQueryHandler : IRequestHandler<GetRestaurantsQuery, GetRestaurantsQueryResponse>
    {
        private readonly IRestaurantsRepository restaurantsRepository;
        private readonly IMapper mapper;

        public GetRestaurantsQueryHandler(IRestaurantsRepository restaurantsRepository, IMapper mapper)
        {
            this.restaurantsRepository = restaurantsRepository;
            this.mapper = mapper;
        }

        public async Task<GetRestaurantsQueryResponse> Handle(GetRestaurantsQuery request, CancellationToken cancellationToken)
        {
            var restaurants = await restaurantsRepository.GetAllAsync(request.PageNumber, request.PageSize, request.CategoryId, request.Name, request.CityName);

            return new GetRestaurantsQueryResponse
            {
                TotalCount = restaurants.TotalCount,
                PageSize = restaurants.PageSize,
                CurrentPage = restaurants.CurrentPage,
                TotalPages = (int)Math.Ceiling(restaurants.TotalCount / (double)restaurants.PageSize),
                Restaurants = mapper.Map<IEnumerable<RestaurantDto>>(restaurants),
                Name = request.Name,
                CityName = request.CityName,
                CategoryId = request.CategoryId
            };
        }
    }
}
