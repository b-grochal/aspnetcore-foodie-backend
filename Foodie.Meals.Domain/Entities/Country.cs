using Foodie.Shared.Entities;
using System.Collections.Generic;

namespace Foodie.Meals.Domain.Entities
{
    public class Country : AuditableEntity
    {
        public string Name { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
