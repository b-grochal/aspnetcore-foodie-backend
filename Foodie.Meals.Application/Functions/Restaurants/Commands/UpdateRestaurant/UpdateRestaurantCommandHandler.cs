using AutoMapper;
using Foodie.Common.Application.Contracts.Infrastructure.Database;
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
        private readonly IRestaurantsRepository _restaurantsRepository;
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateRestaurantCommandHandler(IRestaurantsRepository restaurantsRepository, ICategoriesRepository categoriesRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _restaurantsRepository = restaurantsRepository;
            _categoriesRepository = categoriesRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateRestaurantCommandResponse> Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
        {
            var restaurant = await _restaurantsRepository.GetByIdAsync(request.Id);

            if (restaurant == null)
                throw new RestaurantNotFoundException(request.Id);

            var editedRestaurant = _mapper.Map(request, restaurant);

            var categories = await _categoriesRepository.GetAllAsync(request.CategoriesIds);

            editedRestaurant.Categories.Merge(categories);

            await _restaurantsRepository.UpdateAsync(editedRestaurant);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return _mapper.Map<UpdateRestaurantCommandResponse>(editedRestaurant);
        }
    }
}
