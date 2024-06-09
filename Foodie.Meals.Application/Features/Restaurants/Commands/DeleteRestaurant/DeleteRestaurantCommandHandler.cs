using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Results;
using Foodie.Meals.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Meals.Application.Features.Restaurants.Errors;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommandHandler : IRequestHandler<DeleteRestaurantCommand, Result<DeleteRestaurantCommandResponse>>
    {
        private readonly IRestaurantsRepository _restaurantRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRestaurantCommandHandler(IRestaurantsRepository restaurantRepository, IUnitOfWork unitOfWork)
        {
            _restaurantRepository = restaurantRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<DeleteRestaurantCommandResponse>> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            var restaurantToDelete = await _restaurantRepository.GetByIdAsync(request.Id);

            if (restaurantToDelete is null)
                return Result.Failure<DeleteRestaurantCommandResponse>(RestaurantsErrors.RestaurantNotFoundById(request.Id));

            await _restaurantRepository.DeleteAsync(restaurantToDelete);
            await _unitOfWork.CommitChangesAsync(request.ApplicationUserId, request.ApplicationUserEmail, GetType().Name, cancellationToken);

            return new DeleteRestaurantCommandResponse
            {
                Id = request.Id
            };
        }
    }
}
