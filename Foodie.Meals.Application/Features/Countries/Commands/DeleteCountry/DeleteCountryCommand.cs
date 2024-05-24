using Foodie.Common.Application.Requests.Commands.Interfaces;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Meals.Application.Functions.Countries.Commands.DeleteCountry
{
    public class DeleteCountryCommand : IRequest<Result<DeleteCountryCommandResponse>>, IAuditableCommand
    {
        public int Id { get; set; }

        public int ApplicationUserId { get; set; }

        public string ApplicationUserEmail { get; set; }

        public DeleteCountryCommand(int id)
        {
            Id = id;
        }
    }
}
