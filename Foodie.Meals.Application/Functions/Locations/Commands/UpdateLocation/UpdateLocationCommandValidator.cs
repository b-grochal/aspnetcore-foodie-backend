﻿using FluentValidation;

namespace Foodie.Meals.Application.Functions.Locations.Commands.UpdateLocation
{
    public class UpdateLocationCommandValidator : AbstractValidator<UpdateLocationCommand>
    {
        public UpdateLocationCommandValidator()
        {
            RuleFor(l => l.Id)
                .NotEmpty()
                .WithMessage("{PropertyName} should not be empty");

            RuleFor(l => l.Address)
                .NotEmpty()
                .WithMessage("{PropertyName} should not be empty");

            RuleFor(l => l.PhoneNumber)
                .NotEmpty()
                .WithMessage("{PropertyName} should not be empty");

            RuleFor(l => l.Email)
                .NotEmpty()
                .WithMessage("{PropertyName} should not be empty")
                .EmailAddress()
                .WithMessage("Invalid email address");

            RuleFor(l => l.CityId)
                .NotEmpty()
                .WithMessage("{PropertyName} should not be empty");

            RuleFor(l => l.RestaurantId)
                .NotEmpty()
                .WithMessage("{PropertyName} should not be empty");
        }
    }
}
