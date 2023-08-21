using MediatR;
using System.Text.Json.Serialization;

namespace Foodie.Identity.Application.Functions.MyAccount.Commands.UpdateAccountData
{
    public class UpdateAccountDataCommand : IRequest
    {
        [JsonIgnore]
        public int ApplicationUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
