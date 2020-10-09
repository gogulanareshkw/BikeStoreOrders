using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoreOrders.Domain.Common
{
    public class OrderResults
    {
        public int? OrderId { get; set; }
        public bool? Success { get; set; }
        public string Message { get; set; }
    }
}
