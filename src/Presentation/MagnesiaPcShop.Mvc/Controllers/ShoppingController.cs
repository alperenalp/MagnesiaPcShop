using MagnesiaPcShop.Mvc.Extensions;
using MagnesiaPcShop.Mvc.Models;
using MagnesiaPcShop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
            var productCollection = getProductCollectionFromSession();
            return View(productCollection);
        }

        public async Task<IActionResult> AddProduct(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            var productItem = new ProductItem { Product = product, Quantity = 1 };
            var productCollection = getProductCollectionFromSession();
            productCollection.AddNewProduct(productItem);
            saveToSession(productCollection);
            return Json(new { message = $"{product.Name} sepete eklendi." });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var products = getProductCollectionFromSession();
            products.Delete(id);
            saveToSession(products);
            return RedirectToAction(nameof(Index));
        }

        private ProductCollection getProductCollectionFromSession()
        {
            return HttpContext.Session.GetJson<ProductCollection>("basket") ?? new ProductCollection();
        }

        private void saveToSession(ProductCollection productCollection)
        {
            HttpContext.Session.SetJson("basket", productCollection);
        }
    }
}
