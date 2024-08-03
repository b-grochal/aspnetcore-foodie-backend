using Foodie.Common.Enums;

namespace Foodie.Common.Application.Requests.Interfaces
{
    public interface IApplicationUserLocationRequest
    {
        public int LocationId { get; set; }
 
        public ApplicationUserRole Role { get; set; }
    }
}
