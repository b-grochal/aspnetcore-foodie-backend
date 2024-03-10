using MediatR;
using System.Text.Json.Serialization;

namespace Foodie.Identity.Application.Functions.MyAccount.Commands.ChangeEmail
{
    public class ChangeEmailCommand : IRequest
    {
        [JsonIgnore]
        public int ApplicationUserId { get; set; }
        public string Email { get; set; }
        public string ConfirmEmail { get; set; }
    }
}
