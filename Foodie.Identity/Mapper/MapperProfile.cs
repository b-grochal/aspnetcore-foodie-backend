using AutoMapper;
using Foodie.Identity.Domain.Entities;

namespace Foodie.Identity.API.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Customer, IdentityGrpc.Customer>();
        }
    }
}
