using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Cities.Commands.UpdateCity
{
    public class UpdateCityCommandValidator : AbstractValidator<UpdateCityCommand>
    {
        public UpdateCityCommandValidator()
        {
           RuleFor(c => c.CityId)
            .NotEmpty()
            .WithMessage("{PropertyName} should not be empty"); 

           RuleFor(c => c.Name)
            .NotEmpty()
            .WithMessage("{PropertyName} should not be empty");

           RuleFor(c => c.Country)
            .NotEmpty()
            .WithMessage("{PropertyName} should not be empty");
        }
    }
}
