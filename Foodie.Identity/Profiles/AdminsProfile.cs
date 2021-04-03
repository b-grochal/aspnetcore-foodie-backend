﻿using AutoMapper;
using Foodie.Identity.Commands.Admins;
using Foodie.Identity.Models;
using Foodie.Identity.Responses.Admins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Identity.Profiles
{
    public class AdminsProfile : Profile
    {
        public AdminsProfile()
        {
            CreateMap<ApplicationUser, AdminResponse>();
            CreateMap<CreateAdminCommand, ApplicationUser>();
            CreateMap<EditAdminCommand, ApplicationUser>()
                .ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}