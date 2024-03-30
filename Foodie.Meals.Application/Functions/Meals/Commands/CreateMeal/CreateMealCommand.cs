﻿using Foodie.Common.Application.Requests.Commands.Abstractions;
using MediatR;

namespace Foodie.Meals.Application.Functions.Meals.Commands.CreateMeal
{
    public class CreateMealCommand : IAuditableCommand, IRequest<CreateMealCommandResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int RestaurantId { get; set; }
        public string User { get; set; }
    }
}
