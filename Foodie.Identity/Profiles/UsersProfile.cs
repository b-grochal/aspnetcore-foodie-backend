using AutoMapper;
using Foodie.Identity.Models;
using Foodie.Identity.Responses.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Identity.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<ApplicationUser, UserResponse>();
            CreateMap<CreateUserCommand, ApplicationUser>();
            CreateMap<EditUserCommand, ApplicationUser>()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}
