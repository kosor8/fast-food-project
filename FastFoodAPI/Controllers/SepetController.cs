using Microsoft.AspNetCore.Mvc;
using FastFoodAPI.Models;
using FastFoodAPI.Services;

namespace FastFoodAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SepetController : ControllerBase
    {
        private readonly SepetHizmeti _sepetHizmeti;

        public SepetController()
        {
            _sepetHizmeti = new SepetHizmeti(); // Geçici olarak newliyoruz
        }

        // GET: api/sepet
        [HttpGet]
        public ActionResult<List<SepetOgeleri>> SepetiListele()
        {
            var sepet = _sepetHizmeti.SepetiListele();
            if (sepet.Count == 0)
                return NotFound(new { mesaj = "Sepetiniz boş." });

            return Ok(sepet);
        }

        // POST: api/sepet
        [HttpPost]
        public IActionResult SepeteEkle([FromBody] SepetOgeleri yeniUrun)
        {
            _sepetHizmeti.SepeteEkle(yeniUrun);
            return Ok(new { mesaj = "Ürün sepete eklendi." });
        }

        // DELETE: api/sepet/5
        [HttpDelete("{urunId}")]
        public IActionResult SepetUrunSil(int urunId)
        {
            var sonuc = _sepetHizmeti.SepetUrunSil(urunId);
            if (sonuc)
                return Ok(new { mesaj = "Ürün sepette silindi." });

            return NotFound(new { mesaj = "Ürün bulunamadı." });
        }

        // DELETE: api/sepet
        [HttpDelete]
        public IActionResult SepetiTemizle()
        {
            _sepetHizmeti.SepetiTemizle();
            return Ok(new { mesaj = "Sepet temizlendi." });
        }

        // GET: api/sepet/toplamfiyat
        [HttpGet("toplamfiyat")]
        public ActionResult<decimal> SepetToplamFiyati()
        {
            var toplamFiyat = _sepetHizmeti.SepetToplamFiyati();
            return Ok(toplamFiyat);
        }
    }
}


