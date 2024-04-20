using Foodie.Common.Application.Requests.Commands.Abstractions;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Identity.Application.Features.Auth.Commands.RefreshJwtToken
{
    public class RefreshJwtTokenCommand : IRequest<Result<RefreshJwtTokenCommandResponse>>, IAuditableCommand
    {
        public string JwtToken { get; set; }
        public string RefreshToken { get; set; }
        public string User { get; set; }
    }
}
