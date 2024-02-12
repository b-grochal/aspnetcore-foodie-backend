using AutoMapper;
using Foodie.Common.Linq;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Restaurants.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommandHandler : IRequestHandler<UpdateRestaurantCommand, UpdateRestaurantCommandResponse>
    {
        private readonly IRestaurantsRepository restaurantsRepository;
        private readonly ICategoriesRepository categoriesRepository;
        private readonly IMapper mapper;

        public UpdateRestaurantCommandHandler(IRestaurantsRepository restaurantsRepository, ICategoriesRepository categoriesRepository, IMapper mapper)
        {
            this.restaurantsRepository = restaurantsRepository;
            this.categoriesRepository = categoriesRepository;
            this.mapper = mapper;
        }

        public async Task<UpdateRestaurantCommandResponse> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await restaurantsRepository.GetByIdAsync(request.Id);

            if (restaurant == null)
                throw new RestaurantNotFoundException(request.Id);

            var editedRestaurant = mapper.Map(request, restaurant);

            var categories = await categoriesRepository.GetAllAsync(request.CategoriesIds);

            editedRestaurant.Categories.Merge(categories);

            await restaurantsRepository.UpdateAsync(editedRestaurant);

            return mapper.Map<UpdateRestaurantCommandResponse>(editedRestaurant);
        }
    }
}
