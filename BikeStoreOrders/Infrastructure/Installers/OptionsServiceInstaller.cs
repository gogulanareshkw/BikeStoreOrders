using BikeStoreOrders.Application.Common.Brokers;
using BikeStoreOrders.Application.Common.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoreOrders.Infrastructure.Installers
{
    public class OptionsServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration config, string env)
        {
            services.AddOptions();
            services.Configure<DbConnectionSettings>(config.GetSection("DbConnectionSettings"));
        }
    }
}
