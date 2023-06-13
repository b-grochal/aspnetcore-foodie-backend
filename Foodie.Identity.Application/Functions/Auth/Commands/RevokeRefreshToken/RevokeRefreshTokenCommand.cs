using MediatR;

namespace Foodie.Identity.Application.Functions.Auth.Commands.RevokeRefreshToken
{
    public class RevokeRefreshTokenCommand : IRequest
    {
        public int ApplicationUserId { get; set; }

        public RevokeRefreshTokenCommand(int applicationUserId)
        {
            ApplicationUserId = applicationUserId;
        }
    }
}
