using AutoMapper;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Restaurants.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand, CreateRestaurantCommandResponse>
    {
        private readonly IRestaurantsRepository restaurantsRepository;
        private readonly ICategoriesRepository categoriesRepository;
        private readonly IMapper mapper;

        public CreateRestaurantCommandHandler(IRestaurantsRepository restaurantsRepository, ICategoriesRepository categoriesRepository, IMapper mapper)
        {
            this.restaurantsRepository = restaurantsRepository;
            this.categoriesRepository = categoriesRepository;
            this.mapper = mapper;
        }

        public async Task<CreateRestaurantCommandResponse> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            var restaurant = mapper.Map<Restaurant>(request);
            var categories = await categoriesRepository.GetAllAsync(request.CategoryIds);
            restaurant.Categories = new List<Category>();

            foreach (var category in categories)
            {
                restaurant.Categories.Add(category);
            }

            await restaurantsRepository.CreateAsync(restaurant);
            return mapper.Map<CreateRestaurantCommandResponse>(restaurant);
        }
    }
}
