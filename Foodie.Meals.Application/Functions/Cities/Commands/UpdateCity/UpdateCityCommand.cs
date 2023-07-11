﻿using Foodie.Shared.Commands;
using MediatR;

namespace Foodie.Meals.Application.Functions.Cities.Commands.UpdateCity
{
    public class UpdateCityCommand : AuditableUpdateCommand, IRequest<UpdateCityCommandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}
