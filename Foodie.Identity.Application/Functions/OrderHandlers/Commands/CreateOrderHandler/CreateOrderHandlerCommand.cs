using Foodie.Shared.Commands;
using MediatR;

namespace Foodie.Identity.Application.Functions.OrderHandlers.Commands.CreateOrderHandler
{
    public class CreateOrderHandlerCommand : AuditableCreateCommand, IRequest<CreateOrderHandlerCommandResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int LocationId { get; set; }
    }
}
