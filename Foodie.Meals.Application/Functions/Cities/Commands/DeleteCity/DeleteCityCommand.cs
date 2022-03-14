using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Cities.Commands.DeleteCity
{
    public class DeleteCityCommand : IRequest
    {
        public int CityId { get; set; }

        public DeleteCityCommand(int cityId)
        {
            this.CityId = cityId;
        }
    }
}
