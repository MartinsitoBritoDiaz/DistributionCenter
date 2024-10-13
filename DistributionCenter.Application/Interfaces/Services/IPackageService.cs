using DistributionCenter.Domain.Models;

namespace DistributionCenter.Application.Interfaces.Services
{
    public interface IPackageService
    {
        Task<int> Create(Package package);
        Task<Package> GetByIdAsync(int id);
    }
}
