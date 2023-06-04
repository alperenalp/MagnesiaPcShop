using MagnesiaPcShop.Mvc.Models;
using MagnesiaPcShop.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MagnesiaPcShop.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task<IActionResult> Index(int pageNo = 1, int categoryId = 0)
        {
            PaginationProductViewModel model = await getPaginationProductViewModel(pageNo, categoryId);
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task<PaginationProductViewModel> getPaginationProductViewModel(int pageNo, int categoryId)
        {
            var products = categoryId == 0 ? await _productService.GetProductListAsync() : 
                                             await _productService.GetProductListByCategoryAsync(categoryId);

            var productsCount = products.Count();
            var productPerPage = 2;

            var paginationInfo = new PaginationInfo
            {
                CurrentPage = pageNo,
                ItemsPerPage = productPerPage,
                TotalItems = productsCount,
            };

            var paginatedProduct = products.OrderBy(p => p.Id)
                                           .Skip((pageNo - 1) * productPerPage)
                                           .Take(productPerPage)
                                           .AsEnumerable();

            var model = new PaginationProductViewModel
            {
                Products = paginatedProduct,
                PaginationInfo = paginationInfo
            };
            return model;
        }
    }
}