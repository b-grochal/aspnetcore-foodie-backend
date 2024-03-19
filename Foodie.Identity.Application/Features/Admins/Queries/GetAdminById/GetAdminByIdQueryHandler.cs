using AutoMapper;
using Foodie.Common.Results;
using Foodie.Identity.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Identity.Application.Features.Common;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Admins.Queries.GetAdminById
{
    public class GetAdminByIdQueryHandler : IRequestHandler<GetAdminByIdQuery, Result<GetAdminByIdQueryResponse>>
    {
        private readonly IAdminsRepository adminsRepository;
        private readonly IMapper mapper;

        public GetAdminByIdQueryHandler(IAdminsRepository adminsRepository, IMapper mapper)
        {
            this.adminsRepository = adminsRepository;
            this.mapper = mapper;
        }

        public async Task<Result<GetAdminByIdQueryResponse>> Handle(GetAdminByIdQuery request, CancellationToken cancellationToken)
        {
            var admin = await adminsRepository.GetByIdAsync(request.Id);

            if (admin is null)
                return Result.Failure<GetAdminByIdQueryResponse>(ApplicationUserErrors.ApplicationUserNotFoundById(request.Id));

            return mapper.Map<GetAdminByIdQueryResponse>(admin);
        }
    }
}
