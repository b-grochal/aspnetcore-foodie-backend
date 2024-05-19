using AutoMapper;
using Foodie.Common.Results;
using Foodie.Identity.Application.Contracts.Infrastructure.Database.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Customers.Queries.GetCustomers
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, Result<GetCustomersQueryResponse>>
    {
        private readonly ICustomersRepository customersRepository;
        private readonly IMapper mapper;

        public GetCustomersQueryHandler(ICustomersRepository customersRepository, IMapper mapper)
        {
            this.customersRepository = customersRepository;
            this.mapper = mapper;
        }

        public async Task<Result<GetCustomersQueryResponse>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var result = await customersRepository.GetAllAsync(request.PageNumber, request.PageSize, request.Email);

            return new GetCustomersQueryResponse
            {
                TotalCount = result.TotalCount,
                PageSize = result.PageSize,
                Page = result.Page,
                TotalPages = result.TotalPages,
                Items = mapper.Map<IEnumerable<CustomerDto>>(result.Items),
                Email = request.Email
            };
        }
    }
}
