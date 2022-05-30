﻿using AutoMapper;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var admins = await adminsRepository.GetAllAsync(request.PageNumber, request.PageSize, request.Email);

            return new GetAdminsQueryResponse
            {
                TotalCount = admins.TotalCount,
                PageSize = admins.PageSize,
                CurrentPage = admins.CurrentPage,
                TotalPages = (int)Math.Ceiling(admins.TotalCount / (double)admins.PageSize),
                Admins = mapper.Map<IEnumerable<AdminDto>>(admins),
                Email = request.Email
            };
        }
    }
}