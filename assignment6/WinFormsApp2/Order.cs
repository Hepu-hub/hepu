using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace WinFormsApp2 {
    
    public class Order : IComparable<Order> {

        private readonly List<OrderDetail> details = new List<OrderDetail>();

        public int OrderId { get; set; }

        public string CustomerName { get; set; }

        public DateTime OrderDate { get; set; }

        public float TotalPrice {
            get => Details.Sum(d => d.TotalPrice);
        }

        public List<OrderDetail> Details => details;

        public Order() {
            OrderDate = DateTime.Today;
        }

        public Order(int orderOrderId, string customerName, DateTime creatTime) {
            OrderId = orderOrderId;
            CustomerName = customerName;
            OrderDate = creatTime;
        }

        public void AddDetails(OrderDetail orderDetail) {
            if (Details.Contains(orderDetail)) {
                throw new ApplicationException($"The product ({orderDetail.ProductName}) already exists in order {OrderId}");
            }
            Details.Add(orderDetail);
        }

        public int CompareTo(Order other) {
            return (other == null)?1: OrderId - other.OrderId;
        }

        public override bool Equals(object obj) {
            var order = obj as Order;
            return order != null && OrderId == order.OrderId;
        }

        public override int GetHashCode() {
            return OrderId.GetHashCode();
        }

        public void RemoveDetails(int num) {
            Details.RemoveAt(num);
        }

        public override string ToString() {
            StringBuilder result = new StringBuilder();
            result.Append($"orderId:{OrderId}, customer:({CustomerName})");
            Details.ForEach(detail => result.Append("\n\t" + detail));
            return result.ToString();
        }

    }
}