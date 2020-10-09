using BikeStoreEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoreOrders.Application.Common.Brokers
{
    public interface IDataContext : IDisposable
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Store> Stores { get; set; }
        DbSet<Staff> Staffs { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        DatabaseFacade Database { get; }
        Task SaveChangesAsync();
    }
}
