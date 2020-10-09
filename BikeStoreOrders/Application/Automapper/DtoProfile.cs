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
    public class DtoProfile : Profile
    {
        public DtoProfile()
        {
            CreateMap<Customer, CustomerResponseDto>();
            CreateMap<OrderResults, OrderResponseDto>();
            CreateMap<Order, GetOrdersResponseDto>();
        }
    }
}
