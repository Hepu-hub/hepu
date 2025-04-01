using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace WinFormsApp2
{

    
    public class OrderService
    {


        public List<Order> orders=new List<Order>();
        public List<OrderDetail> Details=new List<OrderDetail>();
        public OrderService()
        {
        }

        //添加订单
        public void AddOrder(Order order)
        {
            if (orders.Contains(order))
            {
                throw new ApplicationException($"the order {order.OrderId} already exists!");
            }

            orders.Add(order);
            foreach (var o in orders)
            {
                foreach (var detail in o.Details) // 直接遍历元素，无需索引
                {
                    Details.Add(detail);
                }
            }
        }

        //更新订单
        public void UpdateOrder(Order order)
        {
            int idx = orders.FindIndex(o => o.OrderId == order.OrderId);
            if (idx < 0)
            {
                throw new ApplicationException($"the order {order.OrderId} doesn't exist!");
            }

            orders.RemoveAt(idx);
            orders.Add(order);
        }

        //根据Id查询订单
        public Order GetOrder(int orderId)
        {
            return orders.FirstOrDefault(o => o.OrderId == orderId);
        }

        //根据Id删除订单
        public void RemoveOrder(int orderId)
        {
            int idx = orders.FindIndex(o => o.OrderId == orderId);
            if (idx >= 0)
            {
                orders.RemoveAt(idx);
            }
        }

        //查询所有订单
        public List<Order> QueryAll()
        {
            return orders;
        }

        //根据客户名查询
        public List<Order> QueryByCustomerName(string customerName)
        {
            var query = orders
                .Where(o => o.CustomerName == customerName)
                .OrderBy(o => o.TotalPrice);
            return query.ToList();
        }

        //根据货物名查询
        public List<Order> QueryByProductName(string productName)
        {
            var query = orders.Where(
                    o => o.Details.Any(d => d.ProductName == productName))
                .OrderBy(o => o.TotalPrice);
            return query.ToList();

        }
        public List<Order> QueryByTotalPrice(float totalPrice)
        {
            var query = orders.Where(o => o.TotalPrice >= totalPrice)
                .OrderBy(o => o.TotalPrice);
            return query.ToList();
        }

        //对orders中的数据进行排序
        public void Sort(Comparison<Order> comparison)
        {
            orders.Sort(comparison);
        }

        public List<Order> GetAllOrders()
        {
            return orders;
        }
        
        //根据传入的条件进行查询
        public IEnumerable<Order> Query(Predicate<Order> condition)
        {
            return orders.Where(o => condition(o)).OrderBy(o => o.TotalPrice);
        }
    }
}
