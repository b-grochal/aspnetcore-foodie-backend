using Foodie.Common.Domain.Entities;
using System.Collections.Generic;

namespace Foodie.Meals.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}
