using Foodie.Common.Results;
using MediatR;

namespace Foodie.Identity.Application.Functions.Admins.Queries.GetAdminById
{
    public class GetAdminByIdQuery : IRequest<Result<GetAdminByIdQueryResponse>>
    {
        public int Id { get; }

        public GetAdminByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
