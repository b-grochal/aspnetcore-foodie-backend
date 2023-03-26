using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Locations.Commands.DeleteLocation
{
    public class DeleteLocationCommand : IRequest<DeleteLocationCommandResponse>
    {
        public int Id { get; set; }

        public DeleteLocationCommand(int id)
        {
            this.Id = id;
        }
    }
}
