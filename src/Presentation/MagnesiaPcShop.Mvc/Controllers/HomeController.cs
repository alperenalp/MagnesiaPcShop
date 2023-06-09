using MagnesiaPcShop.DataTransferObjects.Responses.Product;
using MagnesiaPcShop.Mvc.CacheTools;
using MagnesiaPcShop.Mvc.Models;
using MagnesiaPcShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;

namespace MagnesiaPcShop.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly IMemoryCache _memoryCache;

        public HomeController(ILogger<HomeController> logger, IProductService productService, IMemoryCache memoryCache)
        {
            _logger = logger;
            _productService = productService;
            _memoryCache = memoryCache;
        }

        public async Task<IActionResult> Index(int pageNo = 1, int categoryId = 0, string search = "")
        {
            PaginationProductViewModel model = await getPaginationProductViewModel(pageNo, categoryId, search);
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

        private async Task<PaginationProductViewModel> getPaginationProductViewModel(int pageNo, int categoryId, string search)
        {
            var products = await getProductsFromCacheOrDb(categoryId, search);

            var productsCount = products.Count();
            var productPerPage = 8;

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

        private async Task<IEnumerable<ProductDisplayResponse>> getProductsFromCacheOrDb(int categoryId, string search)
        {
            if (!_memoryCache.TryGetValue("allProducts", out ProductCacheInfo productCacheInfo))
            {
                var options = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(30))
                    .SetPriority(CacheItemPriority.Normal);

                productCacheInfo = new ProductCacheInfo
                {
                    CacheTime = DateTime.Now,
                    Products = await _productService.GetProductListAsync()
                };

                _memoryCache.Set("allProducts", productCacheInfo, options);
            }

            IEnumerable<ProductDisplayResponse> products;
            if (!string.IsNullOrEmpty(search))
            {
                products = await _productService.GetProductListByNameAsync(search);
            }
            else if (categoryId == 0)
            {
                products = productCacheInfo.Products;
            }
            else
            {
                products = await _productService.GetProductListByCategoryAsync(categoryId);
            }
            return products;
        }
    }
}