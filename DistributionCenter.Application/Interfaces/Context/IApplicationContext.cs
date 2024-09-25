using DistributionCenter.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributionCenter.Application.Interfaces.Context
{
    public interface IApplicationContext
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<Package> Packages { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
