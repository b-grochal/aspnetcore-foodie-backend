using Foodie.Common.Results;
using MediatR;

namespace Foodie.Identity.Application.Features.Auth.Commands.RefreshJwtToken
{
    public class RefreshJwtTokenCommand : IRequest<Result<RefreshJwtTokenCommandResponse>>
    {
        public string JwtToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
