using FastFoodAPI.Models;
namespace FastFoodAPI.DataStructures
{
    public class GeriAlYigini
    {
        private Stack<Siparis> yigin = new();

        public void IslemEkle(Siparis siparis)
        {
            yigin.Push(siparis);
        }

        public Siparis? SonIslemiGeriAl()
        {
            if (yigin.Count == 0)
                return null;

            return yigin.Pop();
        }

        public Siparis? EnSonIslem()
        {
            if (yigin.Count == 0)
                return null;

            return yigin.Peek();
        }

        public int ToplamIslem()
        {
            return yigin.Count;
        }

        public List<Siparis> TumIslemleriListele()
        {
            return yigin.ToList();
        }

        public void Temizle()
        {
            yigin.Clear();
        }
    }
}

