using FastFoodMenuAPI.Models;

namespace FastFoodMenuAPI.Services
{
    public class CartService
    {
        private static List<SimpleCartItem> _cart = new List<SimpleCartItem>();

        public List<SimpleCartItem> GetCartItems()
        {
            return _cart;
        }

        public void AddToCart(int productId)
        {
            var product = GetProductById(productId);

            if (product != null)
            {
                // Ürün sepette varsa miktarı arttır
                var existingItem = _cart.FirstOrDefault(item => item.ProductId == productId);
                if (existingItem != null)
                {
                    existingItem.Quantity++;
                }
                else
                {
                    // Ürün sepette yoksa, yeni bir CartItem ekle
                    _cart.Add(new SimpleCartItem
                    {
                        ProductId = product.Id,
                        ProductName = product.Name,
                        Price = product.Price,
                        Quantity = 1,
                        
                    });
                }
            }
        }

        public void RemoveFromCart(int productId)
        {
            // Sepetteki ürünü bul ve sil
            var existingItem = _cart.FirstOrDefault(item => item.ProductId == productId);
            if (existingItem != null)
            {
                if (existingItem.Quantity > 1)
                {
                    // Miktar birden fazla ise sadece miktarı düşür
                    existingItem.Quantity--;
                }
                else
                {
                    // Miktar 1 ise ürünü tamamen sepetten sil
                    _cart.Remove(existingItem);
                }
            }
        }
        public void ClearCart()
        {
            _cart.Clear();
        }


        private ProductNode GetProductById(int productId)
        {
            var menuService = new MenuService();
            var allProducts = menuService.GetMenu()
                                         .SelectMany(category => category.Children)
                                         .ToList();

            return allProducts.FirstOrDefault(p => p.Id == productId);
        }
    }
}

