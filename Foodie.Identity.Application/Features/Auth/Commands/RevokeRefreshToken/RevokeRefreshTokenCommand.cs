using Foodie.Common.Domain.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace Foodie.Identity.Application.Functions.Auth.Commands.RevokeRefreshToken
{
    public class RevokeRefreshTokenCommand : IRequest<Result>
    {
        [JsonIgnore]
        public int ApplicationUserId { get; set; }

        public RevokeRefreshTokenCommand(int applicationUserId)
        {
            ApplicationUserId = applicationUserId;
        }
    }
}
