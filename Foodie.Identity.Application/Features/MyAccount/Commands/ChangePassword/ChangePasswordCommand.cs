using Foodie.Common.Application.Requests.Interfaces;
using Foodie.Common.Application.Requests.Commands.Interfaces;
using Foodie.Common.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace Foodie.Identity.Application.Features.MyAccount.Commands.ChangePassword
{
    public class ChangePasswordCommand : IRequest<Result>, IApplicationUserIdRequest, IAuditableCommand
    {
        [JsonIgnore]
        public int ApplicationUserId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string ApplicationUserEmail { get; set; }
    }
}
