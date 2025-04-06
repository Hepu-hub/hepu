using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WindowsFormsApp2;

namespace WindowsFormsApp2
{
    public class OrderService : IDisposable
    {
        private readonly OrderDbContext _context = new OrderDbContext();

        // 添加订单
        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        // 更新订单
        public void UpdateOrder(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            foreach (var detail in order.Details)
            {
                if (detail.OrderDetailId == 0)
                    _context.Entry(detail).State = EntityState.Added;
                else
                    _context.Entry(detail).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }

        // 删除订单
        public void DeleteOrder(int orderId)
        {
            var order = _context.Orders
                .Include(o => o.Details)
                .FirstOrDefault(o => o.OrderId == orderId);

            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }

        // 获取所有订单
        public List<Order> GetAllOrders()
        {
            return _context.Orders
                .Include(o => o.Details)
                .OrderByDescending(o => o.OrderDate)
                .ToList();
        }

        // 搜索订单
        public List<Order> SearchOrders(string keyword)
        {
            return _context.Orders
                .Include(o => o.Details)
                .Where(o => o.CustomerName.Contains(keyword) ||
                           o.Details.Any(d => d.ProductName.Contains(keyword)))
                .ToList();
        }

        // 获取单个订单
        public Order GetOrderById(int orderId)
        {
            return _context.Orders
                .Include(o => o.Details)
                .FirstOrDefault(o => o.OrderId == orderId);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}