using AutoMapper;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Auth.Commands.SignUp
{
    public class SignUpCommandHandler : IRequestHandler<SignUpCommand, SignUpCommandResponse>
    {
        private readonly ICustomersRepository customersRepository;
        private readonly IMapper mapper;

        public SignUpCommandHandler(ICustomersRepository customersRepository, IMapper mapper)
        {
            this.customersRepository = customersRepository;
            this.mapper = mapper;
        }

        public async Task<SignUpCommandResponse> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            var customer = mapper.Map<Customer>(request);
            await customersRepository.CreateAsync(customer);
            return mapper.Map<SignUpCommandResponse>(customer);
        }
    }
}
