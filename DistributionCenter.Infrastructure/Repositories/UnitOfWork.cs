using DistributionCenter.Application.Interfaces.Repositories;
using DistributionCenter.Domain.Models;
using DistributionCenter.Infrastructure.Context;
using DistributionCenter.Infrastructure.Repositories.Base;

namespace DistributionCenter.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationContext _context;
        private readonly IRepositoryAsync<Customer> _customer;
        private readonly IRepositoryAsync<Employee> _employee;
        private readonly IRepositoryAsync<Package> _package;

        public IRepositoryAsync<Customer> Customers
        {
            get
            {
                return _customer == null ?
                    new RepositoryAsync<Customer>(_context) :
                    _customer;
            }
        }

        public IRepositoryAsync<Employee> Employees
        {
            get
            {
                return _employee == null ?
                    new RepositoryAsync<Employee>(_context) :
                    _employee;
            }
        }

        public IRepositoryAsync<Package> Packages
        {
            get
            {
                return _package == null ?
                    new RepositoryAsync<Package>(_context) :
                    _package;
            }
        }


        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
