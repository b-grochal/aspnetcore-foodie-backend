using Foodie.Common.Domain.Entities;
using Foodie.Common.Domain.Entities.Interfaces;
using System.Collections.Generic;

namespace Foodie.Meals.Domain.Entities
{
    public class City : BaseEntity, ISoftDeletableBaseEntity
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Location> Locations { get; set; }

        public bool IsDeleted { get; set; }
    }
}
