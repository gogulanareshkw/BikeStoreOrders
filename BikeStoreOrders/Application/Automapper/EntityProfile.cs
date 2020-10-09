using AutoMapper;
using BikeStoreEntities;
using BikeStoreOrders.Application.Customers;
using BikeStoreOrders.Application.Orders;
using BikeStoreOrders.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoreOrders.Application.Automapper
{
    public class EntityProfile : Profile
    {
        public EntityProfile()
        {
            CreateMap<CustomerRequestDto, Customer>();
            CreateMap<OrderRequestDto, OrderResults>();
            CreateMap<OrderRequestDto, Order>();
        }
    }
}
