using Foodie.Common.Domain.Entities;
using Foodie.Common.Domain.Entities.Interfaces;

namespace Foodie.Meals.Domain.Entities
{
    public class Location : BaseEntity, ISoftDeletableBaseEntity
    {
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        public bool IsDeleted { get; set; }
    }
}
