using Foodie.Common.Enums;
using Foodie.Identity.Domain.Common.ApplicationUser;
using Foodie.Identity.Domain.Common.ApplicationUser.ValueObjects;

namespace Foodie.Identity.Domain.OrderHandlers
{
    public class OrderHandler : ApplicationUser
    {
        public int LocationId { get; }

        private OrderHandler(string firstName, string lastName, 
            string email, string phoneNumber, string passwordHash,
            int locationId) : base(firstName, lastName, email, 
                phoneNumber, passwordHash, ApplicationUserRole.OrderHandler)
        {
            LocationId = locationId;
        }

        public static OrderHandler Create(string firstName, string lastName,
            string email, string phoneNumber, string passwordHash, int locationId)
        {
            return new OrderHandler(firstName, lastName, email, phoneNumber,
                passwordHash, locationId);
        }
    }
}
