using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributionCenter.Application.Interfaces.Repositories
{
    public interface IRepositoryAsync<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task SaveAsync();
        Task UpdateAsync(TEntity entity);
    }
}
