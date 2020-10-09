using BikeStoreOrders.Application.Common.Brokers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoreOrders.Infrastructure.Installers
{
    public static class ServiceInstallerExtensions
    {
        public static void InstallServices(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
        {
            var serviceInstallers = typeof(Startup).Assembly.ExportedTypes.Where(x => typeof(IServiceInstaller).IsAssignableFrom(x)
                    && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<IServiceInstaller>()
                .ToList();

            serviceInstallers.ForEach(installer =>
            {
                installer.Install(services, configuration, env.EnvironmentName);
            });
        }

    }
}
