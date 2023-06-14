using MediatR;
using System.Text.Json.Serialization;

namespace Foodie.Identity.Application.Functions.Auth.Commands.RevokeRefreshToken
{
    public class RevokeRefreshTokenCommand : IRequest
    {
        [JsonIgnore]
        public int ApplicationUserId { get; set; }

        public RevokeRefreshTokenCommand(int applicationUserId)
        {
            ApplicationUserId = applicationUserId;
        }
    }
}
