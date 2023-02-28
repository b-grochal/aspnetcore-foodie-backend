using AutoMapper;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Domain.Entities;
using Foodie.Identity.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerCommandResponse>
    {
        private readonly ICustomersRepository customersRepository;
        private readonly IApplicationUserRolesRepository applicationUserRolesRepository;
        private readonly IMapper mapper;

        public CreateCustomerCommandHandler(ICustomersRepository customersRepository, IApplicationUserRolesRepository applicationUserRolesRepository, IMapper mapper)
        {
            this.customersRepository = customersRepository;
            this.applicationUserRolesRepository = applicationUserRolesRepository;
            this.mapper = mapper;
        }

        public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = mapper.Map<Customer>(request);

            customer.EmailConfirmed = true;
            customer.PhoneNumberConfirmed = true;

            var identityResult = await customersRepository.CreateAsync(customer, request.Password);

            if (!identityResult.Succeeded)
                throw new ApplicationUserNotCreatedException();

            identityResult = await applicationUserRolesRepository.CreateApplicationUserRole(customer, ApplicationUserRoles.Customer);

            if (!identityResult.Succeeded)
                throw new ApplicationUserRoleNotCreatedException(customer.Id, ApplicationUserRoles.Customer);

            return mapper.Map<CreateCustomerCommandResponse>(customer);
        }
    }
}
