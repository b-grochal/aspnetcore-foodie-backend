using MediatR;

namespace Foodie.Identity.Application.Functions.Admins.Queries.GetAdminById
{
    public class GetAdminByIdQuery : IRequest<GetAdminByIdQueryResponse>
    {
        public int Id { get; }

        public GetAdminByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
