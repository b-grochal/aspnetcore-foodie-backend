using Foodie.Common.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace Foodie.Identity.Application.Features.MyAccount.Commands.ChangeEmail
{
    public class ChangeEmailCommand : IRequest<Result>
    {
        [JsonIgnore]
        public int ApplicationUserId { get; set; }
        public string Email { get; set; }
        public string ConfirmEmail { get; set; }
    }
}
