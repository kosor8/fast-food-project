using Microsoft.AspNetCore.Mvc;
using FastFoodAPI.Models;
using FastFoodAPI.Services;

namespace FastFoodAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderQueueService _orderQueue;

        public OrdersController(OrderQueueService orderQueue)
        {
            _orderQueue = orderQueue;
        }

        [HttpPost]
        public IActionResult AddOrder([FromBody] Order order)
        {
            if (order == null || string.IsNullOrWhiteSpace(order.CustomerName))
                return BadRequest("Geçerli bir sipariş bilgisi gönderin.");

            //order.Timestamp = DateTime.Now;
            _orderQueue.Enqueue(order);
            return Ok("Sipariş başarıyla eklendi.");
        }
        // siparis ekler

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var orders = _orderQueue.GetAll();
            return Ok(orders);
        }
        // siparisleri getirir

        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            var order = _orderQueue.GetById(id);
            if (order == null)
                return NotFound($"ID {id} olan sipariş bulunamadı.");

            return Ok(order);
        }
        // id'si ile getirir

        [HttpGet("next")]
        public IActionResult GetNextOrder()
        {
            var nextOrder = _orderQueue.Peek();
            if (nextOrder == null)
                return NotFound("Kuyrukta sipariş yok.");

            return Ok(nextOrder);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            bool result = _orderQueue.DeleteById(id);
            if (!result)
                return NotFound($"ID {id} olan sipariş bulunamadı.");

            return Ok($"ID {id} olan sipariş silindi.");
        }

        [HttpGet("count")]
        public IActionResult GetOrderCount()
        {
            return Ok(_orderQueue.Count());
        }

        [HttpPost("complete")]
        public IActionResult CompleteNextOrder()
        {
            var completedOrder = _orderQueue.Dequeue();
            if (completedOrder == null)
                return NotFound("Kuyrukta tamamlanacak sipariş yok.");

            return Ok($"Sipariş tamamlandı: {completedOrder.CustomerName} - {completedOrder.Content}");
        }

    }
}
