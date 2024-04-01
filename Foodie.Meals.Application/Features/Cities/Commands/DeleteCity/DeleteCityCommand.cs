using Foodie.Common.Results;
using MediatR;

namespace Foodie.Meals.Application.Functions.Cities.Commands.DeleteCity
{
    public class DeleteCityCommand : IRequest<Result<DeleteCityCommandResponse>>
    {
        public int Id { get; set; }

        public DeleteCityCommand(int id)
        {
            this.Id = id;
        }
    }
}
