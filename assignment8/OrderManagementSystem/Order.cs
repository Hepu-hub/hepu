using System;
using System.Collections.Generic;

namespace OrderManagementSystem
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public decimal TotalAmount => Details?.Sum(d => d.Amount) ?? 0;
        public ICollection<OrderDetail> Details { get; set; } = new List<OrderDetail>();
    }
}