﻿using Foodie.Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Contracts.Infrastructure.Repositories
{
    public interface IAdminsRepository
    {
        Task CreateAsync(Admin admin);
        Task DeleteAsync(Admin admin);
        Task UpdateAsync(Admin admin);
        Task<Admin> GetByIdAsync(string id);
        Task<IReadOnlyList<Admin>> GetAllAsync();
    }
}
