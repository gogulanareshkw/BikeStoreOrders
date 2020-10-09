using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoreOrders.Application.Common.Brokers
{
    public interface IDataContextFactory
    {
        IDataContext SpawnDbContext();
    }
}
