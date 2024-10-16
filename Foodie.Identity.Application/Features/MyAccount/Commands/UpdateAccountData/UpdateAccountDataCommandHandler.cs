﻿using AutoMapper;
using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Results;
using Foodie.Identity.Application.Contracts.Infrastructure.Database.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Features.MyAccount.Commands.UpdateAccountData
{
    public class UpdateAccountDataCommandHandler : IRequestHandler<UpdateAccountDataCommand, Result>
    {
        private readonly IApplicationUsersRepository _applicationUsersRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAccountDataCommandHandler(IApplicationUsersRepository applicationUsersRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _applicationUsersRepository = applicationUsersRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdateAccountDataCommand request, CancellationToken cancellationToken)
        {
            var applicationUser = await _applicationUsersRepository.GetByIdAsync(request.ApplicationUserId);

            if (applicationUser is null)
                Result.Failure(Common.ApplicationUserErrors.ApplicationUserNotFoundById(request.ApplicationUserId));

            applicationUser.Update(request.FirstName, request.LastName, request.PhoneNumber);
            await _applicationUsersRepository.UpdateAsync(applicationUser);

            await _unitOfWork.CommitChangesAsync(request.ApplicationUserId, request.ApplicationUserEmail, GetType().Name, cancellationToken);

            return Result.Success();
        }
    }
}
