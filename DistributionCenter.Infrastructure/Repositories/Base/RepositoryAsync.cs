using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DistributionCenter.Application.Interfaces.Context;
using DistributionCenter.Application.Interfaces.Repositories;
using DistributionCenter.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DistributionCenter.Infrastructure.Repositories.Base
{
    public class RepositoryAsync<TEntity> : IRepositoryAsync<TEntity> where TEntity : class
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public RepositoryAsync(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity) => await _dbSet.AddAsync(entity);

        public async Task DeleteAsync(int id)
        {
            var dbEntity = await _dbSet.FindAsync(id);
            if (dbEntity != null)
            {
                _dbSet.Remove(dbEntity);
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<TEntity> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public async Task SaveAsync() => await _context.SaveChangesAsync();

        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
    }

}
