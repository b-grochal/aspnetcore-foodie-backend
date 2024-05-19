using Foodie.Common.Application.Requests.Commands.Abstractions;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Identity.Application.Functions.OrderHandlers.Commands.UpdateOrderHandler
{
    public class UpdateOrderHandlerCommand : IAuditableCommand, IRequest<Result<UpdateOrderHandlerCommandResponse>>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int LocationId { get; set; }
        public string User { get; set; }
    }
}
