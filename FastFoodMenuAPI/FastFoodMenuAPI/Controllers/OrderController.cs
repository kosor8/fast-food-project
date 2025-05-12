using Microsoft.AspNetCore.Mvc;
using FastFoodMenuAPI.Models;
using FastFoodMenuAPI.Services;

namespace FastFoodMenuAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly CartService _cartService;
        private readonly OrderService _orderService;

        public OrderController(CartService cartService, OrderService orderService)
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

            // Sipariş oluşturulduktan sonra sepeti temizle
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

        [HttpDelete("cancel-order/{orderId}")]
        public IActionResult CancelOrder(int orderId)
        {
            var order = _orderService.GetOrderById(orderId);

            if (order == null)
            {
                return NotFound("Sipariş bulunamadı.");
            }

            if (order.Status != "Hazırlanıyor")
            {
                return BadRequest("Bu sipariş iptal edilemez.");
            }

            order.Status = "İptal Edildi";

            return Ok(new
            {
                message = "Sipariş iptal edildi.",
                orderId = order.OrderId,
                status = order.Status
            });
        }

        // Tüm siparişleri getir
        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders = _orderService.GetAllOrders();
            return Ok(orders);
        }
    }
}

