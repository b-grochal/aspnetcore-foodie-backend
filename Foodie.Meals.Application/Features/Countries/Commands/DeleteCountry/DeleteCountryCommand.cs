using Foodie.Common.Application.Requests.Commands.Abstractions;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Meals.Application.Functions.Countries.Commands.DeleteCountry
{
    public class DeleteCountryCommand : IRequest<Result<DeleteCountryCommandResponse>>, IAuditableCommand
    {
        public int Id { get; set; }

        public string User { get; set; }

        public DeleteCountryCommand(int id)
        {
            Id = id;
        }
    }
}
