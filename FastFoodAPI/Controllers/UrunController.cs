using Microsoft.AspNetCore.Mvc;
using FastFoodAPI.Models;
using FastFoodAPI.Services;
namespace FastFoodAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UrunController : Controller
    {
        private readonly UrunHizmeti _urunHizmeti;

        public UrunController()
        {
            _urunHizmeti = new UrunHizmeti(); // Geçici olarak newliyoruz
        }

        // GET: api/urun
        [HttpGet]
        public ActionResult<List<Urun>> UrunleriListele([FromQuery] string kategori)
        {
            var urunler = _urunHizmeti.UrunleriListele(kategori);
            if (urunler.Count == 0)
                return NotFound(new { mesaj = "Bu kategoriye ait ürün bulunamadı." });

            return Ok(urunler);
        }

        // POST: api/urun
        [HttpPost]
        public IActionResult UrunEkle([FromBody] Urun yeniUrun)
        {
            _urunHizmeti.UrunEkle(yeniUrun);
            return Ok(new { mesaj = "Ürün başarıyla eklendi." });
        }

        // PUT: api/urun/5
        [HttpPut("{urunId}")]
        public IActionResult UrunGuncelle(int urunId, [FromBody] Urun guncellenmisUrun)
        {
            var sonuc = _urunHizmeti.UrunGuncelle(urunId, guncellenmisUrun);
            if (sonuc)
                return Ok(new { mesaj = "Ürün başarıyla güncellendi." });

            return NotFound(new { mesaj = "Ürün bulunamadı." });
        }

        // DELETE: api/urun/5
        [HttpDelete("{urunId}")]
        public IActionResult UrunSil(int urunId)
        {
            var sonuc = _urunHizmeti.UrunSil(urunId);
            if (sonuc)
                return Ok(new { mesaj = "Ürün başarıyla silindi." });

            return NotFound(new { mesaj = "Ürün bulunamadı." });
        }
    }
}   


