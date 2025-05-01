using System.Text.Json;
using Web.Models;

namespace Web.Services
{
    public class OrderQueue
    {
        private Queue<Order> queue = new Queue<Order>();
        private string _filePath = "orders.json";

        public void AddOrder(Order order)
        {
            queue.Enqueue(order);
            SaveOrders();
        }

        public Order NextOrder()
        {
            if (queue.Count == 0)
                return null;
            return queue.Dequeue();
        }

        public List<Order> ListOrders()
        {
            return new List<Order>(queue);
        }

        public bool DeleteOrder(int id)
        {
            var tempQueue = new Queue<Order>();
            bool found = false;

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current.Id == id)
                {
                    found = true;
                    continue;
                }

                tempQueue.Enqueue(current);
            }

            queue = tempQueue;
            SaveOrders(); 
            return found;
        }

        public bool IsEmpty()
        {
            return queue.Count == 0;
        }

        // Siparişleri JSON dosyasına kaydet
        private void SaveOrders()
        {
            var jsonData = JsonSerializer.Serialize(queue);
            File.WriteAllText(_filePath, jsonData);
        }

        public void LoadOrders()
        {
            if (File.Exists(_filePath))
            {
                var jsonData = File.ReadAllText(_filePath);
                if (!string.IsNullOrEmpty(jsonData))
                {
                    var orders = JsonSerializer.Deserialize<Queue<Order>>(jsonData);
                    if (orders != null)
                    {
                        queue = orders;
                    }
                }
            }
        }
    }
}
