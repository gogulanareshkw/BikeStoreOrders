using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoreOrders.Application.Orders.Commands
{
    public class UpdateOrderCommand : IRequest<UpdateOrderResponseDto>
    {
        public UpdateOrderRequestDto UpdateOrderRequestDto { get; set; }
    }
}
