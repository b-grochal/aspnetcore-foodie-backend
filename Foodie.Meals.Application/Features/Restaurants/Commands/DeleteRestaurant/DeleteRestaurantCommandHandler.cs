using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommandHandler : IRequestHandler<DeleteRestaurantCommand, DeleteRestaurantCommandResponse>
    {
        private readonly IRestaurantsRepository _restaurantRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRestaurantCommandHandler(IRestaurantsRepository restaurantRepository, IUnitOfWork unitOfWork)
        {
            _restaurantRepository = restaurantRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteRestaurantCommandResponse> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            var restaurantToDelete = await _restaurantRepository.GetByIdAsync(request.Id);

            if (restaurantToDelete == null)
                throw new RestaurantNotFoundException(request.Id);

            await _restaurantRepository.DeleteAsync(restaurantToDelete);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new DeleteRestaurantCommandResponse
            {
                Id = request.Id
            };
        }
    }
}
