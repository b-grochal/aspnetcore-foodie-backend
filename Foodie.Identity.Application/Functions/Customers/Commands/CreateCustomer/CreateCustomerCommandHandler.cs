using AutoMapper;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Application.Contracts.Infrastructure.Services;
using Foodie.Identity.Domain.Entities;
using Foodie.Identity.Domain.Exceptions;
using Foodie.Shared.Enums;
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
        private readonly IApplicationUsersRepository applicationUsersRepository;
        private readonly IPasswordService passwordService;
        private readonly IMapper mapper;

        public CreateCustomerCommandHandler(ICustomersRepository customersRepository, IApplicationUsersRepository applicationUsersRepository, IPasswordService passwordService, IMapper mapper)
        {
            this.customersRepository = customersRepository;
            this.applicationUsersRepository = applicationUsersRepository;
            this.passwordService = passwordService;
            this.mapper = mapper;
        }

        public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            if ((await applicationUsersRepository.GetByEmailAsync(request.Email)) is not null)
                throw new ApplicationUserAlreadyExistsException(request.Email);

            var customer = mapper.Map<Customer>(request);

            customer.PasswordHash = passwordService.HashPassword(request.Password);
            customer.Role = ApplicationUserRole.Customer;

            await customersRepository.CreateAsync(customer);

            return mapper.Map<CreateCustomerCommandResponse>(customer);
        }
    }
}
