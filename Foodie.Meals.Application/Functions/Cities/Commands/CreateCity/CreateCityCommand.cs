using Foodie.Shared.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Cities.Commands.CreateCity
{
    public class CreateCityCommand : AuditableCreateCommand, IRequest<CreateCityCommandResponse>
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
