using Foodie.Shared.Responses;
using System.Collections.Generic;

namespace Foodie.Identity.Application.Functions.Admins.Queries.GetAdmins
{
    public class GetAdminsQueryResponse : PagedResponse
    {
        public IEnumerable<AdminDto> Admins { get; set; }
        public string Email { get; set; }
    }

    public class AdminDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
