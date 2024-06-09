using Foodie.Common.Application.Requests.Commands.Interfaces;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Identity.Application.Functions.OrderHandlers.Commands.DeleteOrderHandler
{
    public class DeleteOrderHandlerCommand : IRequest<Result<DeleteOrderHandlerCommandResponse>>, IAuditableCommand
    {
        public int Id { get; set; }
        public int ApplicationUserId { get; set; }
        public string ApplicationUserEmail { get; set; }

        public DeleteOrderHandlerCommand(int id)
        {
            this.Id = id;
        }
    }
}
