using DistributionCenter.Domain.Models;
using DistributionCenter.Infrastructure.Interfaces;
using DistributionCenter.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DistributionCenter.Infrastructure.Extensions
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPackageRepository, PackageRepository>( x 
                => new PackageRepository(
                    configuration.GetConnectionString("CosmosDB"),
                    configuration["CosmosConfig:Key"],
                    configuration["CosmosConfig:DatabaseName"],
                    configuration["CosmosConfig:ContainerName"]));
            return services;
        }
    }
}
