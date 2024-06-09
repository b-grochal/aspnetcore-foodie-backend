using Foodie.Common.Domain.Entities;
using Foodie.Common.Domain.Entities.Interfaces;

namespace Foodie.Meals.Domain.Entities
{
    public class Meal : BaseEntity, ISoftDeletableBaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public bool IsDeleted { get; set; }
    }
}
