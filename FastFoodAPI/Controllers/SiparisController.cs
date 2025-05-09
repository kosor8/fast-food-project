using Microsoft.AspNetCore.Mvc;
using FastFoodAPI.Models;
using FastFoodAPI.Services;
namespace FastFoodAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SiparisController : ControllerBase
    {
        private readonly SiparisHizmeti _siparisHizmeti;

        public SiparisController()
        {
            _siparisHizmeti = new SiparisHizmeti(); // Geçici olarak newliyoruz
        }

        // GET: api/siparis
        [HttpGet]
        public ActionResult<List<Siparis>> SiparisleriListele()
        {
            var siparisler = _siparisHizmeti.SiparisleriListele();
            if (siparisler.Count == 0)
                return NotFound(new { mesaj = "Henüz sipariş verilmedi." });

            return Ok(siparisler);
        }

        // GET: api/siparis/5
        [HttpGet("{siparisId}")]
        public ActionResult<Siparis> SiparisGetir(int siparisId)
        {
            var siparis = _siparisHizmeti.SiparisGetir(siparisId);
            if (siparis == null)
                return NotFound(new { mesaj = "Sipariş bulunamadı." });

            return Ok(siparis);
        }

        // POST: api/siparis
        [HttpPost]
        public IActionResult SiparisOlustur([FromBody] Siparis yeniSiparis)
        {
            _siparisHizmeti.SiparisOlustur(yeniSiparis);
            return Ok(new { mesaj = "Sipariş başarıyla oluşturuldu." });
        }

        // PUT: api/siparis/5
        [HttpPut("{siparisId}")]
        public IActionResult SiparisDurumuGuncelle(int siparisId, [FromBody] string yeniDurum)
        {
            var sonuc = _siparisHizmeti.SiparisDurumuGuncelle(siparisId, yeniDurum);
            if (sonuc)
                return Ok(new { mesaj = "Sipariş durumu güncellendi." });

            return NotFound(new { mesaj = "Sipariş bulunamadı." });
        }
    }
}


