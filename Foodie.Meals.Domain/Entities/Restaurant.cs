using Foodie.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Domain.Entities
{
    public class Restaurant : AuditableEntity
    {
        public string Name { get; set; }
        public ICollection<Meal> Meals { get; set; }
        public ICollection<Location> Locations { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
