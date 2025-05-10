using Microsoft.AspNetCore.Mvc;
using FastFoodAPI.Models;
using FastFoodAPI.Data;

namespace FastFoodAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KullaniciController : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult Register(Kullanici kullanici)
        {
            if (KullaniciVeritabani.EpostaVarMi(kullanici.Eposta))
            {
                return BadRequest(new { message = "Bu e-posta ile kayıt zaten mevcut." });
            }

            KullaniciVeritabani.KullaniciEkle(kullanici);
            return Ok(new { message = "Kayıt başarılı!" });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Kullanici giris)
        {
            var resultMessage = KullaniciVeritabani.GirisKontrol(giris.Eposta, giris.Parola);

            if (resultMessage == "Giriş başarılı.")
            {
                return Ok(new { message = resultMessage });
            }

            return BadRequest(new { message = resultMessage });
        }
    }
}
