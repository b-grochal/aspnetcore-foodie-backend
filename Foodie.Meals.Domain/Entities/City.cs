using Foodie.Shared.Entities;
using System.Collections.Generic;

namespace Foodie.Meals.Domain.Entities
{
    public class City : AuditableEntity
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
    }
}
