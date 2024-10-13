using DistributionCenter.Application.Interfaces.Repositories;
using DistributionCenter.Domain.Models;
using DistributionCenter.Infrastructure.Context;
using DistributionCenter.Infrastructure.Repositories;
using DistributionCenter.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DistributionCenter.Infrastructure.Extensions
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IRepositoryAsync<Customer>, RepositoryAsync<Customer>>();
            services.AddTransient<IRepositoryAsync<Package>, RepositoryAsync<Package>>();
            services.AddTransient<IRepositoryAsync<Employee>, RepositoryAsync<Employee>>();
            

            return services;
        }
    }
}
