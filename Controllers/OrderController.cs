using Microsoft.AspNetCore.Mvc;
using FastFoodMenuAPI.Models;
using FastFoodMenuAPI.Services;
using System.Collections.Generic;
using System.Linq;

namespace FastFoodMenuAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly CartService _cartService;
        private readonly OrderService _orderService;

        public OrderController()
        {
            _cartService = new CartService();
            _orderService = new OrderService();
        }

        // Sepeti siparişe çevir
        [HttpPost("place-order")]
        public IActionResult PlaceOrder()
        {
            var cartItems = _cartService.GetCartItems();
            if (!cartItems.Any())
            {
                return BadRequest("Sepet boş.");
            }

            var order = _orderService.CreateOrder(cartItems);
            _cartService.ClearCart();

            return Ok(new
            {
                message = "Sipariş oluşturuldu.",
                orderId = order.OrderId,
                totalItems = order.Items.Count,
                totalPrice = order.Items.Sum(i => i.Price * i.Quantity),
                status = order.Status,
                items = order.Items.Select(i => new
                {
                    i.ProductId,
                    i.ProductName,
                    i.Price,
                    i.Quantity
                })
            });
        }

        // Sıradaki siparişi getir
        [HttpGet("next")]
        public IActionResult GetNextOrder()
        {
            var nextOrder = _orderService.GetNextOrder();
            if (nextOrder == null)
            {
                return NotFound("Sırada sipariş yok.");
            }

            return Ok(nextOrder);
        }

        // Siparişi tamamla
        [HttpPut("complete-order/{orderId}")]
        public IActionResult CompleteOrder(int orderId)
        {
            if (_orderService.CompleteOrder(orderId))
            {
                return Ok(new { message = "Sipariş tamamlandı." });
            }
            return NotFound("Sipariş bulunamadı.");
        }

        // Aktif siparişleri getir
        [HttpGet("active")]
        public IActionResult GetActiveOrders()
        {
            var orders = _orderService.GetActiveOrders();
            return Ok(orders);
        }

        // Tüm siparişleri getir
        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders = _orderService.GetAllOrders();
            return Ok(orders);
        }

        // Siparişi sil
        [HttpDelete("{orderId}")]
        public IActionResult DeleteOrder(int orderId)
        {
            var isDeleted = _orderService.DeleteOrder(orderId);
            if (isDeleted)
            {
                return Ok(new { message = "Sipariş başarıyla silindi." });
            }
            return NotFound(new { message = "Sipariş bulunamadı." });
        }
    }
}
