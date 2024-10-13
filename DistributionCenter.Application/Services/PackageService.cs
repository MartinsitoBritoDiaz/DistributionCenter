using DistributionCenter.Application.Interfaces.Repositories;
using DistributionCenter.Application.Interfaces.Services;
using DistributionCenter.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DistributionCenter.Application.Services
{
    public class PackageService : IPackageService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PackageService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Create(Package package)
        {
            try
            {
                await _unitOfWork.Packages.AddAsync(package);
                _unitOfWork.SaveChanges();
                return package.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Package> GetByIdAsync(int id) => await _unitOfWork.Packages.GetByIdAsync(id);
    }
}
