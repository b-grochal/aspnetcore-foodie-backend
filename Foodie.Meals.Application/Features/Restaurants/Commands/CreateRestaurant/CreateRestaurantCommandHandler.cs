using AutoMapper;
using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Results;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Restaurants.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandHandler : IRequestHandler<CreateRestaurantCommand, Result<CreateRestaurantCommandResponse>>
    {
        private readonly IRestaurantsRepository _restaurantsRepository;
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateRestaurantCommandHandler(IRestaurantsRepository restaurantsRepository, ICategoriesRepository categoriesRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _restaurantsRepository = restaurantsRepository;
            _categoriesRepository = categoriesRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<CreateRestaurantCommandResponse>> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
        {
            var restaurant = _mapper.Map<Restaurant>(request);
            var categories = await _categoriesRepository.GetAllAsync(request.CategoriesIds);
            restaurant.Categories = new List<Category>();

            foreach (var category in categories)
            {
                restaurant.Categories.Add(category);
            }

            await _restaurantsRepository.CreateAsync(restaurant);
            await _unitOfWork.CommitChangesAsync(request.User, cancellationToken);
            return _mapper.Map<CreateRestaurantCommandResponse>(restaurant);
        }
    }
}
