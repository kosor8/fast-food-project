using FastFoodAPI.Models;
using FastFoodAPI.DataStructures;
namespace FastFoodAPI.Services
{
    public class SiparisIsleyici
    {
        private readonly SiparisKuyrugu kuyruk;

        public SiparisIsleyici()
        {
            kuyruk = new SiparisKuyrugu();
        }

        public void SiparisiEkle(Siparis siparis)
        {
            kuyruk.Ekle(siparis);
        }

        public Siparis? SiradakiSiparisiIsle()
        {
            if (!kuyruk.BosMu())
            {
                var siparis = kuyruk.Cikar();
                siparis.Durum = "Hazırlanıyor"; // Durum güncellemesi
                return siparis;
            }
            return null;
        }

        public List<Siparis> BekleyenleriListele()
        {
            return kuyruk.TumSiparisler();
        }

        public bool KuyrukBosMu()
        {
            return kuyruk.BosMu();
        }
    }
}

