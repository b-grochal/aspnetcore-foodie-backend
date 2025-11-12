using Foodie.Common.Api.Authorization;
using Foodie.Common.Api.Controllers;
using Foodie.Common.Api.Results;
using Foodie.Common.Enums;
using Foodie.Orders.Application.Features.Contractors.Queries.GetContractorById;
using Foodie.Orders.Application.Features.Contractors.Queries.GetContractors;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Foodie.Orders.API.Controllers
{
    [Route("api/[controller]")]
    [RequiredRoles(ApplicationUserRole.Admin, ApplicationUserRole.OrderHandler)]
    public class ContractorsController : BaseController
    {
        public ContractorsController(IMediator mediator) : base(mediator) { }

        // GET api/contractors/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContractor(int id)
        {
            var query = new GetContractorByIdQuery(id);
            var result = await mediator.Send(query);

            return result.Match(
                onSuccess: () => Ok(result.Value),
                onFailure: HandleFailure);
        }

        // GET api/contractors
        [HttpGet]
        public async Task<IActionResult> GetContractors([FromQuery] GetContractorsQuery getBuyersQuery)
        {
            var result = await mediator.Send(getBuyersQuery);

            return result.Match(
                onSuccess: () => Ok(result.Value),
                onFailure: HandleFailure);
        }
    }
}
