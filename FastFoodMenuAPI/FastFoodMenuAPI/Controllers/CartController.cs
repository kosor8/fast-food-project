using FastFoodMenuAPI.Models;
using FastFoodMenuAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FastFoodMenuAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly CartService _cartService;

        public CartController()
        {
            _cartService = new CartService();
        }


        [HttpGet]
        public ActionResult<List<CartItem>> GetCart()
        {
            var cartItems = _cartService.GetCartItems();
            return Ok(cartItems);
        }

        // Ürün sepete ekle
        [HttpPost("{productId}")]
        public ActionResult AddToCart(int productId)
        {
            _cartService.AddToCart(productId);
            return Ok();
        }

        // Ürünü sepetteki ürünlerden sil
        [HttpDelete("{productId}")]
        public ActionResult RemoveFromCart(int productId)
        {
            _cartService.RemoveFromCart(productId);
            return Ok();
        }

    }
}
