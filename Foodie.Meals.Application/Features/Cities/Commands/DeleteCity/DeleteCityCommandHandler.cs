using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Cities.Commands.DeleteCity
{
    public class DeleteCityCommandHandler : IRequestHandler<DeleteCityCommand, DeleteCityCommandResponse>
    {
        private readonly ICitiesRepository _citiesRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCityCommandHandler(ICitiesRepository citiesRepository, IUnitOfWork unitOfWork)
        {
            _citiesRepository = citiesRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteCityCommandResponse> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            var city = await _citiesRepository.GetByIdAsync(request.Id);

            if (city == null)
                throw new CityNotFoundException(request.Id);

            await _citiesRepository.DeleteAsync(city);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new DeleteCityCommandResponse
            {
                Id = request.Id
            };
        }
    }
}
