using DistributionCenter.Domain.Models;

namespace DistributionCenter.Infrastructure.Interfaces;

public interface IPackageRepository
{
    Task<IEnumerable<Package>> GetPackagesAsync();
    Task<Package> GetPackageAsync(string id, string type);
    Task<Package> CreatePackageAsync(Package package);
    Task<Package> UpdatePackageAsync(Package package);
    Task<bool> DeletePackageAsync(string id, string type);   
}