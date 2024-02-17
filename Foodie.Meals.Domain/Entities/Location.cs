using Foodie.Common.Domain.Entities;

namespace Foodie.Meals.Domain.Entities
{
    public class Location : BaseEntity
    {
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
