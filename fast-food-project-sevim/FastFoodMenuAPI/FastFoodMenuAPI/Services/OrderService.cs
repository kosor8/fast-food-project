using FastFoodMenuAPI.Models;
using System.Collections.Concurrent;

namespace FastFoodMenuAPI.Services
{
    public class OrderService
    {
        // Thread-safe bir kuyruk kullanıyoruz
        private static ConcurrentQueue<Order> _orderQueue = new ConcurrentQueue<Order>();
        private static int _orderCounter = 1;

        public Order CreateOrder(List<SimpleCartItem> cartItems)
        {
            var newOrder = new Order
            {
                OrderId = _orderCounter++,
                Items = new List<SimpleCartItem>(cartItems),
                Status = "Hazırlanıyor",
                CreatedAt = DateTime.Now
            };

            _orderQueue.Enqueue(newOrder);
            return newOrder;
        }

        public Order? GetNextOrder()
        {
            if (_orderQueue.TryPeek(out var nextOrder))
            {
                return nextOrder;
            }
            return null;
        }

        public bool CompleteOrder(int orderId)
        {
            // Kuyruktan çıkar ve yeni bir kuyruk oluştur
            var tempQueue = new ConcurrentQueue<Order>();
            var found = false;

            while (_orderQueue.TryDequeue(out var order))
            {
                if (order.OrderId == orderId)
                {
                    order.Status = "Tamamlandı";
                    found = true;
                }
                else if (order.Status == "Hazırlanıyor")
                {
                    tempQueue.Enqueue(order);
                }
            }

            // Tamamlanmamış siparişleri geri kuyruğa ekle
            while (tempQueue.TryDequeue(out var order))
            {
                _orderQueue.Enqueue(order);
            }

            return found;
        }

        public List<Order> GetAllOrders()
        {
            return _orderQueue.ToList();
        }

        public List<Order> GetActiveOrders()
        {
            return _orderQueue.Where(o => o.Status == "Hazırlanıyor").ToList();
        }
    }
}