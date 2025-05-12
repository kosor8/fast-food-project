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
                return BadRequest("Bu e-posta ile kayıt zaten mevcut.");
            }

            KullaniciVeritabani.KullaniciEkle(kullanici);
            return Ok("Kayıt başarılı.");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Kullanici giris)
        {
            if (KullaniciVeritabani.GirisKontrol(giris.Eposta, giris.Parola))
            {
                return Ok("Giriş başarılı.");
            }
            return NotFound("Kullanıcı bulunamadı.");
        }
    }
}
