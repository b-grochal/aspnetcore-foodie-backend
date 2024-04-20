using AutoMapper;
using Foodie.Meals.Application.Contracts.Infrastructure.Database.Repositories;
using Grpc.Core;
using MealsGrpc;
using System;
using System.Threading.Tasks;

namespace Foodie.Meals.API.Grpc
{
    public class MealsGrpcService : MealsService.MealsServiceBase
    {
        private readonly ILocationsRepository locationsRepository;
        private readonly IMapper mapper;

        public MealsGrpcService(ILocationsRepository customersRepository, IMapper mapper)
        {
            this.locationsRepository = customersRepository;
            this.mapper = mapper;
        }

        public override async Task<GetLocationResponse> GetLocation(GetLocationRequest request, ServerCallContext context)
        {
            try
            {
                if (request.Id > 0)
                {
                    var location = await locationsRepository.GetByIdWithRelatedDataAsync(request.Id);
                    return new GetLocationResponse
                    {
                        Location = mapper.Map<Location>(location)
                    };
                }
                else
                {
                    return new GetLocationResponse
                    {
                        Error = "ID has invalid value"
                    };
                }
            }
            catch (Exception ex)
            {
                return new GetLocationResponse
                {
                    Error = $"{ex.Message}"
                };
            }
        }
    }
}
