using Foodie.Common.Results;
using MediatR;

namespace Foodie.Meals.Application.Functions.Countries.Commands.DeleteCountry
{
    public class DeleteCountryCommand : IRequest<Result<DeleteCountryCommandResponse>>
    {
        public int Id { get; set; }

        public DeleteCountryCommand(int id)
        {
            Id = id;
        }
    }
}
