using Foodie.Common.Application.Contracts.Infrastructure.Database;
using Foodie.Common.Results;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Application.Contracts.Infrastructure.Services;
using Foodie.Identity.Application.Features.Common;
using Foodie.Identity.Domain.Common.ApplicationUser;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Features.Auth.Commands.SignIn
{
    public class SignInCommandHandler : IRequestHandler<SignInCommand, Result<SignInCommandResponse>>
    {
        private readonly IApplicationUsersRepository _applicationUsersRepository;
        private readonly IRefreshTokensRepository _refreshTokensRepository;
        private readonly IPasswordService _passwordService;
        private readonly IJwtService _jwtService;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly IUnitOfWork _unitOfWork;

        public SignInCommandHandler(
            IApplicationUsersRepository applicationUserRolesRepository,
            IRefreshTokensRepository refreshTokensRepository,
            IPasswordService passwordService,
            IJwtService jwtService,
            IRefreshTokenService refreshTokenService, IUnitOfWork unitOfWork)
        {
            _applicationUsersRepository = applicationUserRolesRepository;
            _refreshTokensRepository = refreshTokensRepository;
            _passwordService = passwordService;
            _jwtService = jwtService;
            _refreshTokenService = refreshTokenService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<SignInCommandResponse>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var applicationUser = await _applicationUsersRepository.GetByEmailAsync(request.Email);

            if (applicationUser is null)
                return Result.Failure<SignInCommandResponse>(ApplicationUserErrors.ApplicationUserNotFoundByEmail(request.Email));

            if (applicationUser.IsLocked)
                return Result.Failure<SignInCommandResponse>(ApplicationUserErrors.ApplicationUserLocked(request.Email));

            if (!applicationUser.IsActive)
                return Result.Failure<SignInCommandResponse>(ApplicationUserErrors.ApplicationUserNotActivated(request.Email));

            if (!_passwordService.VerifyPassword(request.Password, applicationUser.PasswordHash))
                return await HandleInvalidAuthentication(applicationUser, cancellationToken);

            var refreshTokenData = _refreshTokenService.GenerateRefreshToken();

            applicationUser.UpdateRefreshToken(refreshTokenData.RefreshToken, refreshTokenData.ExpirationDate);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new SignInCommandResponse
            {
                JwtToken = _jwtService.GenerateToken(applicationUser),
                RefreshToken = refreshTokenData.RefreshToken
            };
        }

        private async Task<Result<SignInCommandResponse>> HandleInvalidAuthentication(ApplicationUser applicationUser, CancellationToken cancellationToken)
        {
            applicationUser.NoteInvalidAuthentication();

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Failure<SignInCommandResponse>(AuthErrors.ApplicationUserNotAuthenticated(applicationUser.Email));
        }
    }
}
