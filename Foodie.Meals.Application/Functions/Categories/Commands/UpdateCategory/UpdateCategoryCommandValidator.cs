using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(c => c.Id)
            .NotEmpty()
            .WithMessage("{PropertyName} should not be empty");

            RuleFor(c => c.Name)
            .NotEmpty()
            .WithMessage("{PropertyName} should not be empty");
        }
    }
}
