using MediatR;
using System.Text.Json.Serialization;

namespace Foodie.Identity.Application.Functions.MyAccount.Commands.ChangePassword
{
    public class ChangePasswordCommand : IRequest
    {
        [JsonIgnore]
        public int ApplicationUserId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
