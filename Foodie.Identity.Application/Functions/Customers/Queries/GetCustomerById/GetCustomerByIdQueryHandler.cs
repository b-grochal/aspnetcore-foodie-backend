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

namespace Foodie.Identity.Application.Functions.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, GetCustomerByIdQueryResponse>
    {
        private readonly ICustomersRepository customersRepository;
        private readonly IMapper mapper;

        public GetCustomerByIdQueryHandler(ICustomersRepository customersRepository, IMapper mapper)
        {
            this.customersRepository = customersRepository;
            this.mapper = mapper;
        }

        public async Task<GetCustomerByIdQueryResponse> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await customersRepository.GetByIdAsync(request.Id);

            if (customer == null)
                throw new ApplicationUserNotFoundException(request.Id);

            return mapper.Map<GetCustomerByIdQueryResponse>(customer);
        }
    }
}
