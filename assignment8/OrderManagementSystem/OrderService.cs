using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagementSystem
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Order> SearchOrders(string keyword)
        {
            return _context.Orders
                .Include(o => o.Details)
                .Where(o => o.CustomerName.Contains(keyword) ||
                          o.Details.Any(d => d.ProductName.Contains(keyword)))
                .ToList();
        }

        public Order CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return order;
        }

        public void DeleteOrder(int id)
        {
            var order = _context.Orders.Find(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _context.Orders
                .Include(o => o.Details)
                .ToList();
        }

        public Order GetOrderById(int id)
        {
            return _context.Orders
                .Include(o => o.Details)
                .FirstOrDefault(o => o.OrderId == id);
        }

    
        public void UpdateOrder(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}