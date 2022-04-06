using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Restaurants.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommandValidator : AbstractValidator<UpdateRestaurantCommand>
    {
        public UpdateRestaurantCommandValidator()
        {
            RuleFor(r => r.RestaurantId)
                .NotEmpty()
                .WithMessage("{PropertyName} should not be empty");

            RuleFor(r => r.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} should not be empty");

            RuleFor(r => r.CategoryIds)
                .NotEmpty()
                .WithMessage("{PropertyName} should not be empty");
        }
    }
}
