using AutoMapper;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.Admins.Queries.GetAdmins
{
    public class GetAdminsQueryHandler : IRequestHandler<GetAdminsQuery, GetAdminsQueryResponse>
    {
        private readonly IAdminsRepository adminsRepository;
        private readonly IMapper mapper;

        public GetAdminsQueryHandler(IAdminsRepository adminsRepository, IMapper mapper)
        {
            this.adminsRepository = adminsRepository;
            this.mapper = mapper;
        }

        public async Task<GetAdminsQueryResponse> Handle(GetAdminsQuery request, CancellationToken cancellationToken)
        {
            var result = await adminsRepository.GetAllAsync(request.PageNumber, request.PageSize, request.Email);

            return new GetAdminsQueryResponse
            {
                TotalCount = result.TotalCount,
                PageSize = result.PageSize,
                Page = result.Page,
                TotalPages = result.TotalPages,
                Items = mapper.Map<IEnumerable<AdminDto>>(result.Items),
                Email = request.Email
            };
        }
    }
}
