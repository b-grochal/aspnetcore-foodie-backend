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
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<Restaurant> Restaurants { get; set; }
    }
}
