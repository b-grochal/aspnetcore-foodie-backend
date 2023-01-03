using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Domain.Entities;
using Foodie.Shared.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foode.Identity.Infrastructure.Repositories
{
    public class OrderHandlersRepository : BaseApplicationsUsersRepository<OrderHandler>, IOrderHandlersRepository
    {
        public OrderHandlersRepository(UserManager<ApplicationUser> userManager, IdentityDbContext identityDbContext) : base(userManager, identityDbContext) { }
    }
}
