using Foodie.Common.Application.Requests.Commands.Abstractions;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Identity.Application.Functions.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest<Result<DeleteCustomerCommandResponse>>, IAuditableCommand
    {
        public int Id { get; set; }

        public string User { get; set; }

        public DeleteCustomerCommand(int id)
        {
            this.Id = id;
        }
    }
}
