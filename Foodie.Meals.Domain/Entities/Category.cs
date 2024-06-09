using Foodie.Common.Domain.Entities;
using Foodie.Common.Domain.Entities.Interfaces;
using System.Collections.Generic;

namespace Foodie.Meals.Domain.Entities
{
    public class Category : BaseEntity, ISoftDeletableBaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Restaurant> Restaurants { get; set; }

        public bool IsDeleted { get; set; }
    }
}
