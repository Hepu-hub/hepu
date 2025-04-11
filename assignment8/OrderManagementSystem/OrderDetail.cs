namespace OrderManagementSystem
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public string ProductName { get; set; }
        public int  UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Amount => UnitPrice * Quantity;
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}