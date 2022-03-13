using System.Collections.Generic;

namespace Foodie.Meals.Models
{
    public class City
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public ICollection<Location> Locations { get; set; }
    }
}
