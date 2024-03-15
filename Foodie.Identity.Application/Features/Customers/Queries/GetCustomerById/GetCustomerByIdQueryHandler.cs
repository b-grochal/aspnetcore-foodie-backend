using AutoMapper;
using Foodie.Common.Results;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Domain.Common.ApplicationUser.Errors;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Result<GetCustomerByIdQueryResponse>>
    {
        private readonly ICustomersRepository customersRepository;
        private readonly IMapper mapper;

        public GetCustomerByIdQueryHandler(ICustomersRepository customersRepository, IMapper mapper)
        {
            this.customersRepository = customersRepository;
            this.mapper = mapper;
        }

        public async Task<Result<GetCustomerByIdQueryResponse>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await customersRepository.GetByIdAsync(request.Id);

            if (customer is null)
                return Result.Failure<GetCustomerByIdQueryResponse>(ApplicationUserErrors.ApplicationUserNotFoundById(request.Id));

            return mapper.Map<GetCustomerByIdQueryResponse>(customer);
        }
    }
}
