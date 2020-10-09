using BikeStoreEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoreOrders.Application.Orders
{
    public class GetOrdersResponseDto
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public int StoreId { get; set; }
        public int StaffId { get; set; }
        [JsonIgnore]
        public Customer Customer { get; set; }
        [JsonIgnore]
        public Staff Staff { get; set; }
        [JsonIgnore]
        public Store Store { get; set; }
        public ICollection<OrderItem> OrderItem { get; set; }

    }
}
