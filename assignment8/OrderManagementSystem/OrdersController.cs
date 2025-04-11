using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem;

namespace OrderManagementSystem
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/orders
        [HttpGet("search")]
        public ActionResult<IEnumerable<Order>> SearchOrders(string keyword)
        {
            return Ok(_orderService.SearchOrders(keyword));
        }

        // GET: api/orders/5
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(int id)
        {
            var order = _orderService.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        // POST: api/orders
        [HttpPost]
        public ActionResult<Order> CreateOrder(Order order)
        {
            var createdOrder = _orderService.CreateOrder(order);
            return CreatedAtAction(nameof(GetOrder), new { id = createdOrder.OrderId }, createdOrder);
        }

        // PUT: api/orders/5
        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }

            _orderService.UpdateOrder(order);
            return NoContent();
        }

        // DELETE: api/orders/5
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            _orderService.DeleteOrder(id);
            return NoContent();
        }

        // GET: api/orders/search?keyword=xxx
       
    }
}