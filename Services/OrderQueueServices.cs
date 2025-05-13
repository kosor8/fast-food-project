using FastFoodAPI.Models;
using System.Collections.Concurrent;

namespace FastFoodAPI.Services
{
    public class OrderQueueService
    {
        private readonly Queue<Order> _queue = new();
        private int _nextId = 0;
        // siparis kuyrugu tanımlanması

        public void Enqueue(Order order)
        {
            order.ID = _nextId++;
            order.Timestamp = DateTime.Now;
            _queue.Enqueue(order);
        }
        // kuyruga siparisi ekler

        public Order? Dequeue()
        {
            return _queue.Count > 0 ? _queue.Dequeue() : null;
        }
        // kuyruktaki en eski siparisi cıkarır ve doner

        public List<Order> GetAll()
        {
            return _queue.ToList(); // FIFO sırasıyla döner
        }
        // kuyrugun icerigini sırayla(FIFO sırasıyla) listeler

        public Order? GetById(int id)
        {
            return _queue.FirstOrDefault(o => o.ID == id);
        }
        // verilen id degerine göre siparisi siler

        public int Count()
        {
            return _queue.Count;
        }
        // kuyrukta kac siparis oldugu gösterir

        public Order? Peek()
        {
            return _queue.Count > 0 ? _queue.Peek() : null;
        }
        // en onundeki siparisi cıkarmadan gosterir 
        // goz atma islemi

        public bool DeleteById(int id)
        {
            var tempQueue = new Queue<Order>();
            bool deleted = false;

            while (_queue.Count > 0)
            {
                var current = _queue.Dequeue();
                if (current.ID == id)
                {
                    deleted = true;
                    continue;
                }
                tempQueue.Enqueue(current);
            }

            while (tempQueue.Count > 0)
                _queue.Enqueue(tempQueue.Dequeue());

            return deleted;
        }
        // istenen ID'deki siparisi kuyruktan siler
        // FIFO kuyrugunda dogrudan index numarasıyla silme islemini gerceklestirmeyi saglar
        // yeni bir temp kuyruk olusturur ve ana kuyrugun tamamını döndürür 
        // cıkarılmak istenen siparis indeksi geldiginde atlar, en son ana kuyruga temp kuyruk atanır
        // böylece cıkarılmak istenen siparis haric geri kalan siparisler FIFO kuyruguna uygun sekilde korunur 
    }
}
