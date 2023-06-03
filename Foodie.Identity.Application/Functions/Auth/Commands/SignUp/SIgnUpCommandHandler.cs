using AutoMapper;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Application.Contracts.Infrastructure.Services;
using Foodie.Identity.Domain.Entities;
using Foodie.Identity.Domain.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Auth.Commands.SignUp
{
    public class SignUpCommandHandler : IRequestHandler<SignUpCommand, SignUpCommandResponse>
    {
        private readonly ICustomersRepository customersRepository;
        private readonly IPasswordService passwordService;
        private readonly IMapper mapper;

        public SignUpCommandHandler(ICustomersRepository customersRepository, IPasswordService passwordService, IMapper mapper)
        {
            this.customersRepository = customersRepository;
            this.passwordService = passwordService;
            this.mapper = mapper;
        }

        public async Task<SignUpCommandResponse> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            if((await customersRepository.GetByEmailAsync(request.Email)) is not null)
                throw new ApplicationUserAlreadyExistsException(request.Email);

            var customer = mapper.Map<Customer>(request);
            customer.PasswordHash = passwordService.HashPassword(request.Password);
            customer.Role = ApplicationUserRole.Customer;

            await customersRepository.CreateAsync(customer);

            return mapper.Map<SignUpCommandResponse>(customer);
        }
    }
}
