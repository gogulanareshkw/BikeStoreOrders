using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoreOrders.Application.Orders.Commands
{
    public class CreateOrderCommand : IRequest<OrderResponseDto>
    {
        public OrderRequestDto OrderRequestDto { get; set; }
    }
}
