using BikeStoreOrders.Application.Common.Brokers;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoreOrders.Infrastructure.Installers
{
    public class MediatRServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration config, string env)
        {
            services.AddMediatR(typeof(Startup));
        }
    }
}
