using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoreOrders.Application.Orders
{
    public class UpdateOrderResponseDto
    {
        public bool? Success { get; set; }
        public string Message { get; set; }
    }
}
