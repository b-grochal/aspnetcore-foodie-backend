using MediatR;

namespace Foodie.Identity.Application.Functions.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest<DeleteCustomerCommandResponse>
    {
        public int Id { get; set; }

        public DeleteCustomerCommand(int id)
        {
            this.Id = id;
        }
    }
}
