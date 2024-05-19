using Foodie.Common.Application.Requests.Abstractions;
using Foodie.Common.Application.Requests.Commands.Abstractions;
using Foodie.Common.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace Foodie.Identity.Application.Features.MyAccount.Commands.UpdateAccountData
{
    public class UpdateAccountDataCommand : IRequest<Result>, IApplicationUserIdRequest, IAuditableCommand
    {
        [JsonIgnore]
        public int ApplicationUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string User { get; set; }
    }
}
