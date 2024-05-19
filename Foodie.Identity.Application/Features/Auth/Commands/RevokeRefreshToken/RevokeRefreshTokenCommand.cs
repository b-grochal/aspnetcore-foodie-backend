using Foodie.Common.Application.Requests.Abstractions;
using Foodie.Common.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace Foodie.Identity.Application.Features.Auth.Commands.RevokeRefreshToken
{
    public class RevokeRefreshTokenCommand : IRequest<Result>, IApplicationUserIdRequest
    {
        [JsonIgnore]
        public int ApplicationUserId { get; set; }
    }
}
