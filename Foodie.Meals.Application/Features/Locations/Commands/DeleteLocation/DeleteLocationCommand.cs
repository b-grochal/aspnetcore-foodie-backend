using Foodie.Common.Results;
using MediatR;

namespace Foodie.Meals.Application.Functions.Locations.Commands.DeleteLocation
{
    public class DeleteLocationCommand : IRequest<Result<DeleteLocationCommandResponse>>
    {
        public int Id { get; set; }

        public DeleteLocationCommand(int id)
        {
            this.Id = id;
        }
    }
}
