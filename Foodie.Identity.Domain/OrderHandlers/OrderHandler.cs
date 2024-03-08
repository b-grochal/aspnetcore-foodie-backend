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
            int accessFailedCount, bool isLocked, bool isActive, 
            ApplicationUserRole role, RefreshToken refreshToken, int locationId) 
            : base(firstName, lastName, email, phoneNumber, passwordHash, 
                  accessFailedCount, isLocked, isActive, role, refreshToken)
        {
            LocationId = locationId;
        }

        public static OrderHandler Create(string firstName, string lastName,
            string email, string phoneNumber, string passwordHash,
            int accessFailedCount, bool isLocked, bool isActive,
            ApplicationUserRole role, RefreshToken refreshToken, int locationId)
        {
            return new OrderHandler(firstName, lastName, email, phoneNumber,
                passwordHash, accessFailedCount, isLocked, isActive, role, 
                refreshToken, locationId);
        }
    }
}
