using FastFoodMenuAPI.Models;

namespace FastFoodMenuAPI.Services
{
    public class OrderService
    {
        private static List<Order> _orders = new List<Order>();
        private static int _orderCounter = 1;

        public Order CreateOrder(List<SimpleCartItem> cartItems)
        {
            var newOrder = new Order
            {
                OrderId = _orderCounter++,
                Items = new List<SimpleCartItem>(cartItems),
                
                Status = "Hazırlanıyor"
            };

            _orders.Add(newOrder);
            return newOrder;
        }

        public Order? GetOrderById(int orderId)
        {
            return _orders.FirstOrDefault(o => o.OrderId == orderId);
        }



        public List<Order> GetAllOrders()
        {
            return _orders;
        }
    }
}

