using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Web.Models;
using Web.Services;

namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private static readonly OrderQueue _queue = new OrderQueue();
        private static int _nextId = 1;

        [HttpPost]
        public IActionResult AddOrder([FromBody] OrderRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var order = new Order(_nextId++, request.CustomerName, request.OrderDetails);
            _queue.AddOrder(order);
            return CreatedAtAction(nameof(GetNextOrder), new { id = order.Id }, order);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var success = _queue.DeleteOrder(id);
            if (!success)
                return NotFound(new { message = $"{id}'deki sipari� bulunamad�." });
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var orders = _queue.ListOrders();
            return Ok(orders);
        }

        [HttpGet("next")]
        public IActionResult GetNextOrder()
        {
            var nextOrder = _queue.NextOrder();
            if (nextOrder == null)
                return NotFound(new { message = "S�rada Sipari� Yok!" });
            return Ok(nextOrder);
        }
    }

    public class OrderRequest
    {
        [Required(ErrorMessage = "M��teri Ad� Gereklidir!")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Sipari� Detay� Gereklidir!")]
        public string OrderDetails { get; set; }
    }
}
