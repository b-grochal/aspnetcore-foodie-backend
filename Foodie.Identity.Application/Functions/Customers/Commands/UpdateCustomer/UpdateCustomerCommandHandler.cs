using AutoMapper;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, UpdateCustomerCommandResponse>
    {
        private readonly ICustomersRepository customersRepository;
        private readonly IMapper mapper;

        public UpdateCustomerCommandHandler(ICustomersRepository customersRepository, IMapper mapper)
        {
            this.customersRepository = customersRepository;
            this.mapper = mapper;
        }

        public async Task<UpdateCustomerCommandResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await customersRepository.GetByIdAsync(request.CustomerId);

            if (customer == null)
                throw new ApplicationUserNotFoundException(request.CustomerId);

            var updatedCustomer = mapper.Map(request, customer);
            var identityResult = await customersRepository.UpdateAsync(updatedCustomer);

            if (!identityResult.Succeeded)
                throw new ApplicationUserNotUpdatedException(updatedCustomer.Id);

            return mapper.Map<UpdateCustomerCommandResponse>(updatedCustomer);
        }
    }
}
