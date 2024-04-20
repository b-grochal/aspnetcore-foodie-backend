using Foodie.Common.Application.Requests.Commands.Abstractions;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Meals.Application.Functions.Cities.Commands.DeleteCity
{
    public class DeleteCityCommand : IRequest<Result<DeleteCityCommandResponse>>, IAuditableCommand
    {
        public int Id { get; set; }

        public string User { get; set; }

        public DeleteCityCommand(int id)
        {
            this.Id = id;
        }
    }
}
