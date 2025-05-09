using Microsoft.AspNetCore.Mvc;
using FastFoodAPI.Models;
using FastFoodAPI.Services;
namespace FastFoodAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IslemController : ControllerBase
    {
        private readonly SiparisHizmeti _siparisHizmeti;

        public IslemController()
        {
            _siparisHizmeti = new SiparisHizmeti(); // Geçici olarak newliyoruz
        }

        // GET: api/islem
        [HttpGet]
        public ActionResult<List<Siparis>> SiparisleriListele()
        {
            var siparisler = _siparisHizmeti.SiparisleriListele();
            if (siparisler.Count == 0)
                return NotFound(new { mesaj = "Henüz sipariş bulunmamaktadır." });

            return Ok(siparisler);
        }

        // POST: api/islem
        [HttpPost]
        public IActionResult SiparisOlustur([FromBody] Siparis yeniSiparis)
        {
            _siparisHizmeti.SiparisOlustur(yeniSiparis);
            return Ok(new { mesaj = "Sipariş başarıyla oluşturuldu." });
        }

        // PUT: api/islem/5
        [HttpPut("{siparisId}")]
        public IActionResult SiparisDurumuGuncelle(int siparisId, [FromBody] string yeniDurum)
        {
            var sonuc = _siparisHizmeti.SiparisDurumuGuncelle(siparisId, yeniDurum);
            if (sonuc)
                return Ok(new { mesaj = "Sipariş durumu güncellendi." });

            return NotFound(new { mesaj = "Sipariş bulunamadı." });
        }

        // GET: api/islem/5
        [HttpGet("{siparisId}")]
        public ActionResult<Siparis> SiparisGetir(int siparisId)
        {
            var siparis = _siparisHizmeti.SiparisGetir(siparisId);
            if (siparis == null)
                return NotFound(new { mesaj = "Sipariş bulunamadı." });

            return Ok(siparis);
        }
    }
}

