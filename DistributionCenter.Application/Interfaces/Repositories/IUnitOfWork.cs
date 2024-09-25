using DistributionCenter.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributionCenter.Application.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        public IRepositoryAsync<Customer> Customers { get; }
        public IRepositoryAsync<Employee> Employees { get; }
        public IRepositoryAsync<Package> Packages { get; }
        public void SaveChanges();

    }
}
