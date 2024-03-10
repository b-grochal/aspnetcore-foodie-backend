using AutoMapper;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Application.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.MyAccount.Queries.GetAccountData
{
    public class GetAccountDataQueryHandler : IRequestHandler<GetAccountDataQuery, GetAccountDataQueryResponse>
    {
        private readonly IApplicationUsersRepository _applicationUsersRepository;
        private readonly IMapper _mapper;

        public GetAccountDataQueryHandler(IApplicationUsersRepository applicationUsersRepository, IMapper mapper)
        {
            _applicationUsersRepository = applicationUsersRepository;
            _mapper = mapper;
        }

        public async Task<GetAccountDataQueryResponse> Handle(GetAccountDataQuery request, CancellationToken cancellationToken)
        {
            var applicationUser = await _applicationUsersRepository.GetByIdAsync(request.ApplicationUserId);

            if(applicationUser is null)
                throw new ApplicationUserNotFoundException(request.ApplicationUserId);

            return _mapper.Map<GetAccountDataQueryResponse>(applicationUser);
        }
    }
}
