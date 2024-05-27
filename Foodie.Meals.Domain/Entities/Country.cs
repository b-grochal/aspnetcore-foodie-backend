using Foodie.Common.Domain.Entities;
using Foodie.Common.Domain.Entities.Interfaces;
using System.Collections.Generic;

namespace Foodie.Meals.Domain.Entities
{
    public class Country : BaseEntity, ISoftDeletableBaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<City> Cities { get; set; }

        public bool IsDeleted { get; set; }
    }
}
