using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Customers.Commands.DeleteCustomer
{
    internal class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, DeleteCustomerCommandResponse>
    {
        private readonly ICustomersRepository customersRepository;

        public DeleteCustomerCommandHandler(ICustomersRepository customersRepository)
        {
            this.customersRepository = customersRepository;
        }

        public async Task<DeleteCustomerCommandResponse> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await customersRepository.GetByIdAsync(request.Id);

            if (customer == null)
                throw new ApplicationUserNotFoundException(request.Id);

            var identityResult = await customersRepository.DeleteAsync(customer);

            if(!identityResult.Succeeded)
                throw new ApplicationUserNotDeletedException(customer.Id);

            return new DeleteCustomerCommandResponse
            {
                Id = request.Id
            };
        }
    }
}
