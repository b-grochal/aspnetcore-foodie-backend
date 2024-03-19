using AutoMapper;
using Foodie.Common.Results;
using Foodie.Identity.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Identity.Application.Features.Common;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.MyAccount.Queries.GetAccountData
{
    public class GetAccountDataQueryHandler : IRequestHandler<GetAccountDataQuery, Result<GetAccountDataQueryResponse>>
    {
        private readonly IApplicationUsersRepository _applicationUsersRepository;
        private readonly IMapper _mapper;

        public GetAccountDataQueryHandler(IApplicationUsersRepository applicationUsersRepository, IMapper mapper)
        {
            _applicationUsersRepository = applicationUsersRepository;
            _mapper = mapper;
        }

        public async Task<Result<GetAccountDataQueryResponse>> Handle(GetAccountDataQuery request, CancellationToken cancellationToken)
        {
            var applicationUser = await _applicationUsersRepository.GetByIdAsync(request.ApplicationUserId);

            if (applicationUser is null)
                return Result.Failure<GetAccountDataQueryResponse>(ApplicationUserErrors.ApplicationUserNotFoundById(request.ApplicationUserId));

            return _mapper.Map<GetAccountDataQueryResponse>(applicationUser);
        }
    }
}
