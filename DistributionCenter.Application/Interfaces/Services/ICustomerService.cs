using DistributionCenter.Domain.Models;

namespace DistributionCenter.Application.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<int> Create(Customer customer);
        Task<Package> GetByIdAsync(int id);
    }
}
