using Foodie.Common.Results;
using MediatR;

namespace Foodie.Identity.Application.Functions.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdQuery : IRequest<Result<GetCustomerByIdQueryResponse>>
    {
        public int Id { get; }

        public GetCustomerByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
