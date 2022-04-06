using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Cities.Commands.CreateCity
{
    public class CreateCityCommandResponse
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
