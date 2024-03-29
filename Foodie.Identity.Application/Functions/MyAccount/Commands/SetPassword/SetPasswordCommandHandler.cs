﻿using Foodie.Common.Infrastructure.Cache;
using Foodie.Common.Infrastructure.Cache.Interfaces;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Application.Contracts.Infrastructure.Services;
using Foodie.Identity.Application.Exceptions;
using Foodie.Identity.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.MyAccount.Commands.SetPassword
{
    public class SetPasswordCommandHandler : IRequestHandler<SetPasswordCommand>
    {
        private readonly IApplicationUsersRepository _applicationUsersRepository;
        private readonly ICacheService _cacheService;
        private readonly IPasswordService _passwordService;

        public SetPasswordCommandHandler(IApplicationUsersRepository applicationUsersRepository, ICacheService cacheService, IPasswordService passwordService)
        {
            _applicationUsersRepository = applicationUsersRepository;
            _cacheService = cacheService;
            _passwordService = passwordService;
        }

        public async Task<Unit> Handle(SetPasswordCommand request, CancellationToken cancellationToken)
        {
            var applicationUser = await _cacheService.GetAsync<ApplicationUser>(CachePrefixes.SetPasswordToken,
                                                          string.Empty,
                                                          CacheParameters.SetPasswordToken,
                                                          request.SetPasswordToken);

            if (applicationUser is null)
                throw new InvalidSetPasswordTokenException();

            applicationUser = await _applicationUsersRepository.GetByIdAsync(applicationUser.Id);

            if (applicationUser is null)
                throw new ApplicationUserNotFoundException();

            applicationUser.PasswordHash = _passwordService.HashPassword(request.Password);

            await _applicationUsersRepository.UpdateAsync(applicationUser);

            await _cacheService.RemoveAsync(CachePrefixes.SetPasswordToken, string.Empty, CacheParameters.SetPasswordToken,
                                                          request.SetPasswordToken);

            return Unit.Value;
        }
    }
}
