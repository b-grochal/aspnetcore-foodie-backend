using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Cities.Commands.DeleteCity
{
    public class DeleteCityCommand : IRequest<DeleteCityCommandResponse>
    {
        public int Id { get; set; }

        public DeleteCityCommand(int id)
        {
            this.Id = id;
        }
    }
}
