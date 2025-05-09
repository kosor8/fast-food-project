using FastFoodAPI.Models;
using System.Collections.Generic;
using System.Linq;
namespace FastFoodAPI.DataStructures
{
    public class SiparisKuyrugu
    {
        private Queue<Siparis> kuyruk;

        public SiparisKuyrugu()
        {
            kuyruk = new Queue<Siparis>();
        }

        public void Ekle(Siparis siparis)
        {
            kuyruk.Enqueue(siparis);
        }

        public Siparis Cikar()
        {
            return kuyruk.Dequeue();
        }

        public bool BosMu()
        {
            return kuyruk.Count == 0;
        }

        public List<Siparis> TumSiparisler()
        {
            return kuyruk.ToList();
        }
    }
}
