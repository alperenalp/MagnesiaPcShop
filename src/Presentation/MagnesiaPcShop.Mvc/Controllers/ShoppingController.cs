using MagnesiaPcShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace MagnesiaPcShop.Mvc.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly IProductService _productService;

        public ShoppingController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddProduct(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            return Json(new { message = $"{product.Name} sepete eklendi." });
        }
    }
}
