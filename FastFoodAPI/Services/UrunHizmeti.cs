using FastFoodAPI.Models;

namespace FastFoodAPI.Services
{
    public class UrunHizmeti // yönetıcı urunle iligili bir şey gümcellemek ısterse örneğin fiyat açıklama vs kullanılır
    {
        private List<Urun> urunler;

        public UrunHizmeti()
        {
            urunler = new List<Urun>
            {
                new Urun { Id = 1, Kategori = "Burgerler", Isim = "Cheeseburger", Aciklama = "Lezzetli cheddar peyniri ve dana etinden yapılmış klasik burger", Fiyat = 75.00m, ResimUrl = "cheeseburger.jpg" },
                new Urun { Id = 2, Kategori = "Taco'lar", Isim = "Klasik Taco", Aciklama = "Özel taco baharatları ile doldurulmuş taco", Fiyat = 90.00m, ResimUrl = "taco.jpg" },
                new Urun { Id = 3, Kategori = "Pizza'lar", Isim = "Margarita Pizza", Aciklama = "Fırınlanmış pizza üzerine mozzarella ve domates", Fiyat = 75.00m, ResimUrl = "margarita.jpg" },
                new Urun { Id = 4, Kategori = "Burgerler", Isim = "Double Cheeseburger", Aciklama = "İki kat cheddar peyniri ve dana etinden yapılmış lezzetli burger", Fiyat = 105.00m, ResimUrl = "double_cheeseburger.jpg" },
                new Urun { Id = 5, Kategori = "Pizza'lar", Isim = "Pepperoni Pizza", Aciklama = "Bol pepperoni ile hazırlanmış pizza", Fiyat = 150.00m, ResimUrl = "pepperoni_pizza.jpg" }
            };
        }

        // Ürünleri kategoriye göre listele
        public List<Urun> UrunleriListele(string kategori)
        {
            return urunler.Where(u => u.Kategori.Equals(kategori, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public void UrunEkle(Urun yeniUrun)
        {
            urunler.Add(yeniUrun);
        }

        public bool UrunSil(int urunId)
        {
            var urun = urunler.FirstOrDefault(u => u.Id == urunId);
            if (urun != null)
            {
                urunler.Remove(urun);
                return true;
            }
            return false;
        }

        public bool UrunGuncelle(int urunId, Urun guncellenmisUrun)
        {
            var urun = urunler.FirstOrDefault(u => u.Id == urunId);
            if (urun != null)
            {
                urun.Isim = guncellenmisUrun.Isim;
                urun.Aciklama = guncellenmisUrun.Aciklama;
                urun.Fiyat = guncellenmisUrun.Fiyat;
                urun.ResimUrl = guncellenmisUrun.ResimUrl;
                urun.Kategori = guncellenmisUrun.Kategori;
                return true;
            }
            return false;
        }
    }
}

