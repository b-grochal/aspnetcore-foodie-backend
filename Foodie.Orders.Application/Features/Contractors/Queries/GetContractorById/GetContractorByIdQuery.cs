using Foodie.Common.Results;
using MediatR;

namespace Foodie.Orders.Application.Features.Contractors.Queries.GetContractorById
{
    public class GetContractorByIdQuery : IRequest<Result<GetContractorByIdQueryResponse>>
    {
        public int Id { get; set; }

        public GetContractorByIdQuery(int id)
        {
            Id = id;
        }
    }
}
