namespace FastFoodMenuAPI.Models
{
    public class BasitSepetUrunu
    {
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public decimal Fiyat { get; set; }
        public int Adet { get; set; }

        public decimal ToplamFiyat => Fiyat * Adet;

        public BasitSepetUrunu(int urunId, string urunAdi, decimal fiyat, int adet)
        {
            UrunId = urunId;
            UrunAdi = urunAdi;
            Fiyat = fiyat > 0 ? fiyat : throw new ArgumentException("Fiyat sıfırdan büyük olmalıdır.");
            Adet = adet > 0 ? adet : throw new ArgumentException("Adet sıfırdan büyük olmalıdır.");
        }
    }

    public class SepetOzeti
    {
        public List<BasitSepetUrunu> Urunler { get; set; } = new List<BasitSepetUrunu>();

        public decimal ToplamTutar => Urunler.Sum(urun => urun.ToplamFiyat);
        public int ToplamAdet => Urunler.Sum(urun => urun.Adet);

        public void UrunEkle(BasitSepetUrunu urun)
        {
            if (urun == null) throw new ArgumentNullException(nameof(urun));
            Urunler.Add(urun);
        }
    }
}