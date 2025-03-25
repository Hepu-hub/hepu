namespace ConsoleApp10;

using System;
using System.Collections.Generic;
using System.Linq;

class client
{
    private string name;
    private string address;
    private string phone;

    public client(string name, string address, string phone)
    {
        this.name = name;
        this.address = address;
        this.phone = phone;
    }

    public override string ToString()
    {
        return name+":"+address+":"+phone;
    }
}
class Order
{
    public int OrderId { get; set; }
    public double OrderCost { get; set; }
    public string OrderItemId { get; set; }
    public string OrderClient { get; set; }

    public Order(int orderId, double orderCost, string orderItemId, string orderClient)
    {
        this.OrderId = orderId; 
        this.OrderCost = orderCost;
        this.OrderItemId = orderItemId;
        this.OrderClient = orderClient;
    }

    public override bool Equals(object? obj)
    {
        Order? Checkorder = obj as Order;
        return Checkorder != null && Checkorder.OrderId == this.OrderId&&Checkorder.OrderCost == this.OrderCost&&Checkorder.OrderItemId == this.OrderItemId&&Checkorder.OrderClient == this.OrderClient;
    }

    public override string ToString()
    {
        return OrderId + "-" + OrderCost + "-" + OrderItemId+"-"+OrderClient;
    }
}

class OrderDetail
{
    public int OrderId { get; set; }
    public double OrderCost { get; set; }
    public string OrderItemId { get; set; }
    public string OrderClient { get; set; }
    
    public override bool Equals(object? obj)
    {
        Order orderEql = obj as Order;
        return obj!=null&&this.OrderId==orderEql.OrderId&&orderEql.OrderCost==this.OrderCost&&orderEql.OrderItemId==this.OrderItemId&&orderEql.OrderClient==this.OrderClient;
    }

    public override string ToString()
    {
        return OrderId + "-" + OrderCost + "-" + OrderItemId+"-"+OrderClient;
    }

    public OrderDetail(int orderId, double orderCost, string orderItemId, string orderClient)
    {
        this.OrderId = orderId;
        this.OrderCost = orderCost;
        this.OrderItemId = orderItemId;
        this.OrderClient = orderClient;
    }
}

class OrderService
{
    private  List<Order> orders = new List<Order>();

    public  void AddOrder(int orderId, double orderCost, string orderItemId ,string orderClient)
    {
        bool addOrder = true;
        Order newOrder = new Order(orderId, orderCost, orderItemId, orderClient);
        for (int i = 0; i < orders.Count; i++)
        {
            if (orders[i].Equals(newOrder))
            {
                addOrder = false;
            }
        }

        if (addOrder)
        {
            orders.Add(newOrder);
        }
        else
        {
            throw new Exception("Order is already added");
        }
    }

    public  void RemoveOrder(int orderId)
    {
        bool result = false;
        for (int i = 0; i < orders.Count; i++)
        {
            if (orders[i].OrderId == orderId)
            {
                try
                {
                    orders.RemoveAt(i);
                    result = true;
                }catch (ArgumentOutOfRangeException ex)
                {
                    throw new InvalidOperationException($"Failed to remove order at index {i}", ex);
                }
            }
        }
        if (!result)
        {
            throw new Exception($"$Order {orderId} not found");
        }
    }

    public  void UpdateOrder(int orderId, double orderCost, string orderItemId, string orderClient)
    {
        bool result = false;
        int index=-1;
        for (int i = 0; i < orders.Count; i++)
        {
            if (orders[i].OrderId == orderId)
            {
                result = true;
                index = i;
            }
        }

        if (result)
        {
            try
            {
                orders[index].OrderCost = orderCost;
                orders[index].OrderItemId = orderItemId;
                orders[index].OrderClient = orderClient;
                orders[index].OrderId = orderId;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw new InvalidOperationException($"Failed to update order at index {index}", ex);
            }
        }
        else
        {
            throw new Exception($"$Order {orderId} not found");
        }
    }

    public  Order CheckOrder()
    {
        
        Order checkOrder = null;
            Console.WriteLine("Checking order...");
            Console.WriteLine("Please input your Check Mode:");
            Console.WriteLine("1. 按订单号查询");
            Console.WriteLine("2. 按商品名称查询");
            Console.WriteLine("3. 按客户查询");
            Console.WriteLine("4. 按金额范围查询");
            int orderMode = int.Parse(Console.ReadLine());
            switch (orderMode)
            {
                    case 1:
                        Console.WriteLine("please enter your order ID:");
                        int orderId = int.Parse(Console.ReadLine());
                        checkOrder=orders.Where(order => order.OrderId == orderId).OrderByDescending(order=>order.OrderCost).FirstOrDefault();
                        break;
                    case 2:
                        Console.WriteLine("please enter your orderItemID:");
                        string orderItemId = Console.ReadLine();
                        checkOrder=orders.Where(order=>order.OrderItemId==orderItemId).OrderByDescending(order=>order.OrderCost).FirstOrDefault();
                        break;
                    case 3:
                        Console.WriteLine("please enter your order client:");
                        string orderClient = Console.ReadLine();
                        checkOrder=orders.Where(order => order.OrderClient == orderClient).OrderByDescending(order => order.OrderCost).FirstOrDefault();
                        break;
                    case 4:
                        Console.WriteLine("please enter your order cost:");
                        double orderCost = double.Parse(Console.ReadLine());
                        checkOrder=orders.Where(order => order.OrderCost == orderCost).OrderByDescending(order => order.OrderCost).FirstOrDefault();
                        break;
                    default:
                        throw new Exception($"$OrderMode {orderMode} not found");
            }
          return checkOrder;
    }

    public void swap(List<Order> orders, int i, int j)
    {
        int temp1 = orders[i].OrderId;
        double temp2 = orders[i].OrderCost;
        string temp3 = orders[i].OrderItemId;
        string temp4 = orders[i].OrderClient;
        orders[i].OrderId = orders[j].OrderId;
        orders[i].OrderCost = orders[j].OrderCost;
        orders[i].OrderItemId = orders[j].OrderItemId;
        orders[i].OrderClient = orders[j].OrderClient;
        orders[j].OrderId = orders[i].OrderId;
        orders[j].OrderCost = orders[i].OrderCost;
        orders[j].OrderItemId = orders[i].OrderItemId;
        orders[j].OrderClient = orders[i].OrderClient;
    }
    
    public void OrderTheOrdersByDeFault()
    {
        for (int i = 0; i < orders.Count; i++)
        {
            for (int j = i + 1; j < orders.Count; j++)
            {
                if (orders[i].OrderId > orders[j].OrderId)
                {
                    swap(orders,j,i);
                }
            }
        }
    }

    public  void OrderTheOrdersByAction(Action<List<Order>> action)
    {
        action(orders);
    }
    
}

class Program
{
    static void Main(string[] args)
    {
        OrderService orderServiceTest = new OrderService();
        while (true)
        {
            Console.WriteLine("welcome to order service");
            Console.WriteLine("1. 添加订单");
            Console.WriteLine("2. 删除订单");
            Console.WriteLine("3. 修改订单");
            Console.WriteLine("4. 查询订单");
            Console.WriteLine("5. 排序订单");
            Console.WriteLine("0. 退出");
            Console.Write("请选择操作: ");
            int Choice = int.Parse(Console.ReadLine());
            switch (Choice)
            {
                case 1:
                    Console.WriteLine("please enter your order ID:");
                    int orderId = int.Parse(Console.ReadLine());
                    Console.WriteLine("please enter your order cost:");
                    double orderCost = double.Parse(Console.ReadLine());
                    Console.WriteLine("please enter your order item ID:");
                    string orderItemId = Console.ReadLine();
                    Console.WriteLine("please enter your order client:");
                    string orderClient = Console.ReadLine();
                    orderServiceTest.AddOrder(orderId, orderCost, orderItemId, orderClient);
                    break;
                case 2:
                    Console.WriteLine("please enter your order ID which you would like to delete:");
                    int orderIdtest = int.Parse(Console.ReadLine());
                    orderServiceTest.RemoveOrder(orderIdtest);
                    break;
                case 3:
                    Console.WriteLine("please enter your order id which you would like to updata:");
                    int orderIdtest1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("please enter your order Cost which you would like to update:");
                    double orderCosttest1 = double.Parse(Console.ReadLine());
                    Console.WriteLine("please enter your order item id which you would like to update:");
                    string orderItemIdtest1 = Console.ReadLine();
                    Console.WriteLine("please enter your order client which you would like to update:");
                    string orderClienttest1 = Console.ReadLine();
                    orderServiceTest.UpdateOrder(orderIdtest1,orderCosttest1,orderItemIdtest1,orderClienttest1);
                    break;
                case 4:
                    orderServiceTest.CheckOrder();
                    break;
                case 5:
                    Console.WriteLine("please enter your order list orderway which you would like to :");
                    Console.WriteLine("1.orders ordered default order");
                    Console.WriteLine("2.orders ordered the way you want,but you need to achieve by yourself");
                    int choice1 = int.Parse(Console.ReadLine());
                    orderServiceTest.OrderTheOrdersByDeFault();
                    break;
                default:
                    return;
            }

        }
    }
}