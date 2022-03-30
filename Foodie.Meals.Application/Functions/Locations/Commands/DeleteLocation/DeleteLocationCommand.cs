﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Locations.Commands.DeleteLocation
{
    public class DeleteLocationCommand : IRequest
    {
        public int LocationId { get; set; }

        public DeleteLocationCommand(int locationId)
        {
            this.LocationId = locationId;
        }
    }
}