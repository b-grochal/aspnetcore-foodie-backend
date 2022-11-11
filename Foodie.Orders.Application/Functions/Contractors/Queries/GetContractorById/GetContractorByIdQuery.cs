using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Functions.Contractors.Queries.GetContractorById
{
    public class GetContractorByIdQuery : IRequest<GetContractorByIdQueryResponse>
    {
        public int ContractorId { get; set; }

        public GetContractorByIdQuery(int contractorId)
        {
            ContractorId = contractorId;
        }
    }
}
