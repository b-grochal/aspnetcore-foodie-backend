using Foodie.Common.Domain.Entities;
using System.Collections.Generic;

namespace Foodie.Meals.Domain.Entities
{
    public class Restaurant : AuditableEntity<int>
    {
        public string Name { get; set; }
        public virtual ICollection<Meal> Meals { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
