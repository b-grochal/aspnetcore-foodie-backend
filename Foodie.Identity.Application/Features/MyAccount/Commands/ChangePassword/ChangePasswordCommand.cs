using Foodie.Common.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace Foodie.Identity.Application.Features.MyAccount.Commands.ChangePassword
{
    public class ChangePasswordCommand : IRequest<Result>
    {
        [JsonIgnore]
        public int ApplicationUserId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
