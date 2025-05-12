using Microsoft.AspNetCore.Mvc;
using FastFoodMenuAPI.Models;
using FastFoodMenuAPI.Services;

namespace FastFoodMenuAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly CartService _cartService;

        public CartController(CartService cartService)
        {
            _cartService = new CartService();
        }

        // Sepeti getir (ürün adı, fiyat ve toplam)
        [HttpGet]
        public ActionResult<CartSummary> GetCart()
        {
            var items = _cartService.GetCartItems();

            var summary = new CartSummary
            {
                Items = items.Select(i => new SimpleCartItem
                {
                    ProductId = i.ProductId,
                    ProductName = i.ProductName,
                    Price = i.Price * i.Quantity,
                    Quantity = i.Quantity
                }).ToList(),
                TotalPrice = items.Sum(i => i.Price * i.Quantity)
            };

            return Ok(summary);
        }

        // Sepete ürün ekle
        [HttpPost("add/{productId}")]
        public IActionResult AddToCart(int productId)
        {
            _cartService.AddToCart(productId);
            return Ok("Ürün sepete eklendi.");
        }

        // Sepetten ürün çıkar
        [HttpDelete("remove/{productId}")]
        public IActionResult RemoveFromCart(int productId)
        {
            _cartService.RemoveFromCart(productId);
            return Ok("Ürün sepetten çıkarıldı.");
        }
    }
}
