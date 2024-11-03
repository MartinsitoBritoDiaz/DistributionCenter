using DistributionCenter.Domain.Models;

namespace DistributionCenter.Application.Interfaces.Services
{
    public interface IPackageService
    {
        Task<string> Create(Package package);
        Task<Package> GetByIdAsync(int id);
        Task<IEnumerable<Package>> GetAllAsync();
        Task<bool> DeleteAsync(int id);
    }

}
