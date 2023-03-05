using Foodie.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}
