using BikeStoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoreOrders.Domain.Common
{
    public class GetOrders
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public int StoreId { get; set; }
        public int StaffId { get; set; }
        //        public Customer Customer { get; set; }
        public Staff Staff { get; set; }
        public Store Store { get; set; }
        public OrderItem OrderItem { get; set; }
    }
}
