using Foodie.Common.Results;
using MediatR;

namespace Foodie.Identity.Application.Functions.OrderHandlers.Commands.DeleteOrderHandler
{
    public class DeleteOrderHandlerCommand : IRequest<Result<DeleteOrderHandlerCommandResponse>>
    {
        public int Id { get; set; }

        public DeleteOrderHandlerCommand(int id)
        {
            this.Id = id;
        }
    }
}
