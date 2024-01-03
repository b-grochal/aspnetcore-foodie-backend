using Foodie.Common.Domain.Entities;

namespace Foodie.Meals.Domain.Entities
{
    public class Meal : AuditableEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
