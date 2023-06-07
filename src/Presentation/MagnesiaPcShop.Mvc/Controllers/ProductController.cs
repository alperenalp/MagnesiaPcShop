using MagnesiaPcShop.DataTransferObjects.Requests.Product;
using MagnesiaPcShop.Entities;
using MagnesiaPcShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MagnesiaPcShop.Mvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProductListAsync();
            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await getCategoriesForSelectList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNewProductRequest createNewProductRequest)
        {
            if(ModelState.IsValid)
            {
                await _productService.CreateProductAsync(createNewProductRequest);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = await getCategoriesForSelectList();
            return View();
        }

        private async Task<IEnumerable<SelectListItem>> getCategoriesForSelectList()
        {
            var categories = await _categoryService.GetCategoryListAsync();
            return categories.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() });
        }
    }
}
