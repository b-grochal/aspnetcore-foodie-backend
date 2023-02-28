using Foodie.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Domain.Entities
{
    public class City : AuditableEntity
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public ICollection<Location> Locations { get; set; }
    }
}
