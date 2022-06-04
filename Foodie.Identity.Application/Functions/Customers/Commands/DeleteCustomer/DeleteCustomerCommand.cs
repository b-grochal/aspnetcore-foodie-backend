using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest<DeleteCustomerCommandResponse>
    {
        public string CustomerId { get; set; }

        public DeleteCustomerCommand(string customerId)
        {
            this.CustomerId = customerId;
        }
    }
}
