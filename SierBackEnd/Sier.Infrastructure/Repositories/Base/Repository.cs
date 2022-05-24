using Sier.Core.Repositories.Base;
using Sier.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sier.Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly sierContext _sierContext;

        public Repository(sierContext sierContext)
        {
            _sierContext = sierContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _sierContext.Set<T>().AddAsync(entity);
            await _sierContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _sierContext.Set<T>().Remove(entity);
            await _sierContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _sierContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _sierContext.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            await _sierContext.SaveChangesAsync();
        }
    }
}
