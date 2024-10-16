﻿using Foodie.Common.Application.Contracts.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foode.Identity.Infrastructure.Database.Repositories
{
    public class BaseIdentityRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly IdentityDbContext dbContext;

        public BaseIdentityRepository(IdentityDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<T> CreateAsync(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            dbContext.Set<T>().Remove(entity);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            dbContext.Set<T>().Update(entity);
        }
    }
}
