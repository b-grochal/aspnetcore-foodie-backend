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

namespace Foodie.Identity.Application.Functions.Admins.Queries.GetAdminById
{
    public class GetAdminByIdQueryHandler : IRequestHandler<GetAdminByIdQuery, GetAdminByIdQueryResponse>
    {
        private readonly IAdminsRepository adminsRepository;
        private readonly IMapper mapper;

        public GetAdminByIdQueryHandler(IAdminsRepository adminsRepository, IMapper mapper)
        {
            this.adminsRepository = adminsRepository;
            this.mapper = mapper;
        }

       public async Task<GetAdminByIdQueryResponse> Handle(GetAdminByIdQuery request, CancellationToken cancellationToken)
       {
            var admin = await adminsRepository.GetByIdAsync(request.AdminId);

            if (admin == null)
                throw new AdminNotFoundException(request.AdminId);

            return mapper.Map<GetAdminByIdQueryResponse>(admin);
       }
    }
}
