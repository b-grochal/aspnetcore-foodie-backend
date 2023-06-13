using MediatR;

namespace Foodie.Identity.Application.Functions.Auth.Commands.RefreshJwtToken
{
    public class RefreshJwtTokenCommand : IRequest<RefreshJwtTokenCommandResponse>
    {
        public string JwtToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
