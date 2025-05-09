using FastFoodAPI.Models;

namespace FastFoodAPI.Services
{
    public class SiparisHizmeti // siparişleri yönetir
    {
        private List<Siparis> siparisler;

        public SiparisHizmeti()
        {
            siparisler = new List<Siparis>();  // Siparişler başta boş
        }

        public void SiparisOlustur(Siparis yeniSiparis)
        {
            siparisler.Add(yeniSiparis); // Siparişi listeye ekle
        }

        public List<Siparis> SiparisleriListele()
        {
            return siparisler;
        }

        public bool SiparisDurumuGuncelle(int siparisId, string yeniDurum)
        {
            var siparis = siparisler.FirstOrDefault(s => s.SiparisId == siparisId); 
            if (siparis != null)
            {
                siparis.Durum = yeniDurum; // Durumunu güncelle
                return true;
            }
            return false;
        }

        // Siparişi ID'ye göre getirmek
        public Siparis SiparisGetir(int siparisId)
        {
            return siparisler.FirstOrDefault(s => s.SiparisId == siparisId); 
        }
    }
}

