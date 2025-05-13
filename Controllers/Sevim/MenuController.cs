using Microsoft.AspNetCore.Mvc;
using FastFoodMenuAPI.Models;
using FastFoodMenuAPI.Services;
namespace FastFoodMenuAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly MenuService _menuService;

        public MenuController()
        {
            _menuService = new MenuService(); 
        }


        // Belirli bir kategoriyi ve ürünlerini döndüren endpoint
        [HttpGet("categories/{categoryId}")]
        public ActionResult<List<ProductNode>> GetCategoryProducts(int categoryId)
        {
            
            var menu = _menuService.GetMenu();

            var category = menu.FirstOrDefault(c => c.Id == categoryId);

            if (category == null)
            {
                return NotFound("Kategori bulunamadı.");
            }

            return Ok(category.Children);
        }

        [HttpGet]
        public ActionResult<List<CategoryNode>> GetFullMenu()
        {
            var menu = _menuService.GetMenu();

            // Menü verisini olduğu gibi döndürüyoruz
            return Ok(menu);
        }
    }
}
