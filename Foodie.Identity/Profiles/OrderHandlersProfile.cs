using AutoMapper;
using Foodie.Identity.Models;
using Foodie.Identity.Responses.OrderHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Identity.Profiles
{
    public class OrderHandlersProfile : Profile
    {
        public OrderHandlersProfile()
        {
            CreateMap<ApplicationUser, OrderHandlerResponse>();
            CreateMap<CreateOrderHandlerCommand, ApplicationUser>();
            CreateMap<EditOrderHandlerCommand, ApplicationUser>()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
