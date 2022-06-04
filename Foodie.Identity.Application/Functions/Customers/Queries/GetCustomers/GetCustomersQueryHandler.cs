using AutoMapper;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Customers.Queries.GetCustomers
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, GetCustomersQueryResponse>
    {
        private readonly ICustomersRepository customersRepository;
        private readonly IMapper mapper;

        public GetCustomersQueryHandler(ICustomersRepository customersRepository, IMapper mapper)
        {
            this.customersRepository = customersRepository;
            this.mapper = mapper;
        }

        public async Task<GetCustomersQueryResponse> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await customersRepository.GetAllAsync(request.PageNumber, request.PageSize, request.Email);

            return new GetCustomersQueryResponse
            {
                TotalCount = customers.TotalCount,
                PageSize = customers.PageSize,
                CurrentPage = customers.CurrentPage,
                TotalPages = (int)Math.Ceiling(customers.TotalCount / (double)customers.PageSize),
                Customers = mapper.Map<IEnumerable<CustomerDto>>(customers),
                Email = request.Email
            };
        }
    }
}
