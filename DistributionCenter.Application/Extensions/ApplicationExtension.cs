using DistributionCenter.Application.Interfaces.Services;
using DistributionCenter.Application.Services;
using DistributionCenter.Infrastructure.Extensions;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DistributionCenter.Application.Extensions
{
    public static class ApplicationExtension
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IPackageService>(provider =>
            {
                var cosmosClient = new CosmosClient("AccountEndpoint=https://distributecenterdb.documents.azure.com:443/;AccountKey=");
                return new PackageService(cosmosClient, "DistributeCenterDB", "Packages");
            });

            return services;
        }
    }
}
