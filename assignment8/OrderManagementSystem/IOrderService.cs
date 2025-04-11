using OrderManagementSystem;
using System.Collections.Generic;

namespace OrderManagementSystem
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);
        Order CreateOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int id);
        IEnumerable<Order> SearchOrders(string keyword);
    }
}