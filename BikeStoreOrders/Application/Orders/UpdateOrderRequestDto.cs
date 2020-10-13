using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoreOrders.Application.Orders
{
    public class UpdateOrderRequestDto
    {
        public int OrderId { get; set; }
        public int OrderItemId { get; set; }
        public int CustomerId { get; set; }
        public int StaffId { get; set; }
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string OrderStatus { get; set; }

    }
}
