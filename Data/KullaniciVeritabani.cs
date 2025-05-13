using System.Text.Json;
using FastFoodAPI.Models;

namespace FastFoodAPI.Data
{
    public static class KullaniciVeritabani
    {
        private static readonly string dosyaYolu = "kullanicilar.json";

        public static List<Kullanici> KullanicilariGetir()
        {
            if (!File.Exists(dosyaYolu)) return new List<Kullanici>();
            string json = File.ReadAllText(dosyaYolu);
            return JsonSerializer.Deserialize<List<Kullanici>>(json);
        }

        public static void KullaniciEkle(Kullanici yeniKullanici)
        {
            var kullanicilar = KullanicilariGetir();
            kullanicilar.Add(yeniKullanici);
            string json = JsonSerializer.Serialize(kullanicilar, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(dosyaYolu, json);
        }

        public static bool EpostaVarMi(string eposta)
        {
            return KullanicilariGetir().Any(k => k.Eposta == eposta);
        }

        public static string GirisKontrol(string eposta, string parola)
        {
            var kullanicilar = KullanicilariGetir();
            var kullanici = kullanicilar.FirstOrDefault(k => k.Eposta == eposta);

            if (kullanici == null)
            {
                return "Kayıtlı kullanıcı bulunamadı. Lütfen kayıt olunuz.";
            }

            if (kullanici.Parola != parola)
            {
                return "Şifre hatalı.";
            }

            return "Giriş başarılı.";
        }
    }
}
