using FastFoodAPI.Models;

namespace FastFoodAPI.Services
{
    public class SepetHizmeti // sepeti yönetir ürün ekler siler listeler toplam fıyat hesaplar
    {
        private List<SepetOgeleri> sepet;

        public SepetHizmeti()
        {
            sepet = new List<SepetOgeleri>();
        }

        public void SepeteEkle(SepetOgeleri yeniUrun)
        {
            var mevcutUrun = sepet.FirstOrDefault(u => u.UrunId == yeniUrun.UrunId);
            if (mevcutUrun != null)
            {
                mevcutUrun.Miktar += yeniUrun.Miktar;
            }
            else
            {
                sepet.Add(yeniUrun);
            }
        }

        // Sepetteki tüm ürünler listelenir
        public List<SepetOgeleri> SepetiListele()
        {
            return sepet;
        }

        //girilen urun ıd ye göre urunu sıler
        public bool SepetUrunSil(int urunId)
        {
            var urun = sepet.FirstOrDefault(u => u.UrunId == urunId);
            if (urun != null)
            {
                sepet.Remove(urun);
                return true;
            }
            return false;
        }
        public void SepetiTemizle()
        {
            sepet.Clear();
        }

        public decimal SepetToplamFiyati()
        {
            return sepet.Sum(u => u.Fiyat * u.Miktar); 
        }
    }
}  


