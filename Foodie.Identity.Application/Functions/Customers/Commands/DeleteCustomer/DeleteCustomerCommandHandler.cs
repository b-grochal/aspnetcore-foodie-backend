﻿using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
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
            var customer = await customersRepository.GetByIdAsync(request.CustomerId);

            if (customer == null)
                throw new CustomerNotFoundException(request.CustomerId);

            await customersRepository.DeleteAsync(customer);

            return new DeleteCustomerCommandResponse
            {
                CustomerId = request.CustomerId
            };
        }
    }
}