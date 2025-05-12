using Microsoft.AspNetCore.Mvc;
using FastFoodAPI.Models;
using FastFoodAPI.Data;

namespace FastFoodAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KullaniciController : ControllerBase
    {
        // Kullanıcı kayıt
        [HttpPost("register")]
        public IActionResult KayitOl([FromBody] Kullanici yeniKullanici)
        {
            var mevcut = KullaniciVeritabani.KullanicilariGetir()
                .Any(k => k.Eposta == yeniKullanici.Eposta);

            if (mevcut)
                return BadRequest(new { message = "Bu e-posta ile zaten kayıt olunmuş." });

            KullaniciVeritabani.KullaniciEkle(yeniKullanici);
            return Ok(new { message = "Kayıt başarılı!" });
        }

        // Kullanıcı giriş
        [HttpPost("login")]
        public IActionResult GirisYap([FromBody] Kullanici girisKullanici)
        {
            var kullanicilar = KullaniciVeritabani.KullanicilariGetir();

            var kullanici = kullanicilar.FirstOrDefault(k => k.Eposta == girisKullanici.Eposta);

            if (kullanici == null)
                return NotFound(new { message = "E-postaya ait kayıt bulunamadı." });

            if (kullanici.Parola != girisKullanici.Parola)
                return Unauthorized(new { message = "Parola hatalı." });

            return Ok(new
            {
                message = "Giriş başarılı!",
                ad = kullanici.Ad,
                eposta = kullanici.Eposta
            });
        }

        // E-posta ile isim alma
        [HttpGet("isim")]
        public IActionResult KullaniciAdiniGetir([FromQuery] string eposta)
        {
            var kullanici = KullaniciVeritabani.KullanicilariGetir()
                .FirstOrDefault(k => k.Eposta == eposta);

            if (kullanici == null)
                return NotFound(new { message = "Kullanıcı bulunamadı." });

            return Ok(new { ad = kullanici.Ad });
        }
    }
}
