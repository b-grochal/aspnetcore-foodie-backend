using MediatR;

namespace Foodie.Meals.Application.Functions.Cities.Commands.DeleteCity
{
    public class DeleteCityCommand : IRequest<DeleteCityCommandResponse>
    {
        public int Id { get; set; }

        public DeleteCityCommand(int id)
        {
            this.Id = id;
        }
    }
}
