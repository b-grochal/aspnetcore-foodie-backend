using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Restaurants.Commands.CreateRestaurant
{
    public class CreateRestaurantCommandValidator : AbstractValidator<CreateRestaurantCommand>
    {
        public CreateRestaurantCommandValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} should not be empty");

            RuleFor(r => r.CategoriesIds)
                .NotEmpty()
                .WithMessage("{PropertyName} should not be empty");
        }
    }
}
