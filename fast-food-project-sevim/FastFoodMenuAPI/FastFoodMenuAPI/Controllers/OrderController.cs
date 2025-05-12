using Microsoft.AspNetCore.Mvc;
using FastFoodMenuAPI.Models;
using FastFoodMenuAPI.Services;
using System.IO;
using System.Text.Json;
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
        private readonly string _ordersFilePath = "orders.json"; // Store orders in a JSON file

        public OrderController()
        {
            _cartService = new CartService();
            _orderService = new OrderService();
            // Ensure the orders file exists
            if (!System.IO.File.Exists(_ordersFilePath))
            {
                System.IO.File.WriteAllText(_ordersFilePath, "[]"); // Initialize with an empty JSON array
            }
        }

        // Helper method to load orders from the JSON file
        private List<Order> LoadOrders()
        {
            string json = System.IO.File.ReadAllText(_ordersFilePath);
            try
            {
                // Attempt to deserialize the JSON.  Handle potential errors.
                List<Order> orders = JsonSerializer.Deserialize<List<Order>>(json);
                return orders ?? new List<Order>(); // Ensure we return a List<Order>, even if deserialization returns null
            }
            catch (JsonException ex)
            {
                // Log the error (important for debugging)
                Console.Error.WriteLine($"Error deserializing JSON: {ex.Message}");
                // Return an empty list to avoid crashing the application.  
                // Consider alternative error handling (e.g., throwing an exception, redirecting)
                return new List<Order>();
            }
        }

        // Helper method to save orders to the JSON file
        private void SaveOrders(List<Order> orders)
        {
            //Use the System.Text.Json options to ensure proper formatting (indented for readability)
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(orders, options);
            System.IO.File.WriteAllText(_ordersFilePath, json);
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

            // Load existing orders, add the new order, and save
            List<Order> orders = LoadOrders();
            orders.Add(order);
            SaveOrders(orders);

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
            List<Order> orders = LoadOrders(); // Load orders from file
            var order = orders.FirstOrDefault(o => o.OrderId == orderId);

            if (order == null)
            {
                return NotFound("Sipariş bulunamadı.");
            }

            if (order.Status != "Hazırlanıyor")
            {
                return BadRequest("Bu sipariş iptal edilemez.");
            }

            order.Status = "İptal Edildi";
            SaveOrders(orders); // Save the updated order

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
            List<Order> orders = LoadOrders();  // Load orders from the file.
            return Ok(orders);
        }
    }
}
