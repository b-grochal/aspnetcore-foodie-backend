using Foodie.Common.Application.Requests.Abstractions;
using Foodie.Common.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace Foodie.Identity.Application.Features.MyAccount.Commands.ChangeEmail
{
    public class ChangeEmailCommand : IRequest<Result>, IApplicationUserIdRequest
    {
        [JsonIgnore]
        public int ApplicationUserId { get; set; }
        public string Email { get; set; }
        public string ConfirmEmail { get; set; }
    }
}
