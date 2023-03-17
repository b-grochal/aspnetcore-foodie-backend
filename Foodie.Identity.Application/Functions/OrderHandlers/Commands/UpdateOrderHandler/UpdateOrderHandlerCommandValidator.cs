using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Functions.OrderHandlers.Commands.UpdateOrderHandler
{
    public class UpdateOrderHandlerCommandValidator : AbstractValidator<UpdateOrderHandlerCommand>
    {
        public UpdateOrderHandlerCommandValidator()
        {
            RuleFor(c => c.Id)
            .NotEmpty()
            .WithMessage("{PropertyName} should not be empty");

            RuleFor(c => c.FirstName)
            .NotEmpty()
            .WithMessage("{PropertyName} should not be empty");

            RuleFor(c => c.LastName)
            .NotEmpty()
            .WithMessage("{PropertyName} should not be empty");

            RuleFor(c => c.PhoneNumber)
            .NotEmpty()
            .WithMessage("{PropertyName} should not be empty");

            RuleFor(c => c.Email)
            .NotEmpty()
            .WithMessage("{PropertyName} should not be empty")
            .EmailAddress()
            .WithMessage("Invalid email address")
            .Must(email => email.EndsWith("@foodie.com"))
            .WithMessage("Only emails in foodie.com domain are allowed for admins and order handlers");
        }
    }
}
