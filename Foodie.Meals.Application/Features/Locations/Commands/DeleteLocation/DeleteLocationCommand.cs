using Foodie.Common.Application.Requests.Commands.Interfaces;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Meals.Application.Functions.Locations.Commands.DeleteLocation
{
    public class DeleteLocationCommand : IRequest<Result<DeleteLocationCommandResponse>>, IAuditableCommand
    {
        public int Id { get; set; }

        public int ApplicationUserId { get; set; }

        public string ApplicationUserEmail { get; set; }

        public DeleteLocationCommand(int id)
        {
            this.Id = id;
        }
    }
}
