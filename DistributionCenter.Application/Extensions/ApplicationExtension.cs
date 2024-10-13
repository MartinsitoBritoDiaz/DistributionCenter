using DistributionCenter.Application.Interfaces.Services;
using DistributionCenter.Application.Services;
using DistributionCenter.Infrastructure.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DistributionCenter.Application.Extensions
{
    public static class ApplicationExtension
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped<IPackageService, PackageService>();
            return services;
        }
    }
}
