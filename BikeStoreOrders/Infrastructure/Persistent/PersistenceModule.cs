using Autofac;
using BikeStoreOrders.Application.Common.Brokers;
using BikeStoreOrders.Application.Common.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoreOrders.Infrastructure.Persistent
{
    public class PersistenceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c =>
            {
                var options = c.Resolve<IOptions<DbConnectionSettings>>();
                var dbConnectionSettings = options.Value;
                var dbContextOptionsBuilder = new DbContextOptionsBuilder<DataContext>()
                    .UseSqlServer(dbConnectionSettings.BikeStoreDbContext);

                return new DataContext(dbContextOptionsBuilder.Options);
            }).As<IDataContext>().InstancePerDependency().ExternallyOwned();

            builder.RegisterType<DataContextFactory>().As<IDataContextFactory>()
                .InstancePerLifetimeScope();
        }

    }
}
