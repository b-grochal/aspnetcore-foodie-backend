using Foodie.Common.Application.Requests.Commands.Abstractions;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Meals.Application.Functions.Locations.Commands.DeleteLocation
{
    public class DeleteLocationCommand : IRequest<Result<DeleteLocationCommandResponse>>, IAuditableCommand
    {
        public int Id { get; set; }

        public string User { get; set; }

        public DeleteLocationCommand(int id)
        {
            this.Id = id;
        }
    }
}
