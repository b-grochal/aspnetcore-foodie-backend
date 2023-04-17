using AutoMapper;
using Foodie.Basket.API.Dtos;
using Foodie.Basket.API.Functions.CustomerBaskets.Commands.UpdateCustomerBasket;
using Foodie.Basket.API.Functions.CustomerBaskets.Queries.GetCustomerBasketByCustomerId;
using Foodie.Basket.Model;

namespace Foodie.Basket.API.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CustomerBasketItem, CustomerBasketItemDto>()
                .ReverseMap();
            CreateMap<CustomerBasket, GetCustomerBasketByCustomerIdQueryResponse>();
            CreateMap<UpdateCustomerBasketCommand, CustomerBasket>();
            CreateMap<CustomerBasket, UpdateCustomerBasketCommandResponse>();
        }
    }
}
