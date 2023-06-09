using MagnesiaPcShop.DataTransferObjects.Requests.Product;
using MagnesiaPcShop.DataTransferObjects.Responses.Product;
using MagnesiaPcShop.Entities;
using MagnesiaPcShop.Mvc.CacheTools;
using MagnesiaPcShop.Mvc.Models;
using MagnesiaPcShop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MagnesiaPcShop.Mvc.Controllers
{
    [Authorize(Roles = "Admin,Editor")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(int pageNo = 1, int categoryId = 0, string search = "")
        {
            PaginationProductViewModel model = await getPaginationProductViewModel(pageNo, categoryId, search);
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await getCategoriesForSelectList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNewProductRequest createNewProductRequest)
        {
            if (ModelState.IsValid)
            {
                await _productService.CreateProductAsync(createNewProductRequest);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = await getCategoriesForSelectList();
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Categories = await getCategoriesForSelectList();
            var products = await _productService.GetProductForUpdateAsync(id);
            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, UpdateProductRequest request)
        {
            var isProductExists = await _productService.IsProductExistsAsync(id);
            if (isProductExists)
            {
                if (ModelState.IsValid)
                {
                    await _productService.UpdateProductAsync(request);
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.Categories = await getCategoriesForSelectList();
                return View();
            }
            return NotFound();

        }

        public async Task<IActionResult> Delete(int id)
        {
            var isProductExists = await _productService.IsProductExistsAsync(id);
            if (isProductExists)
            {
                await _productService.DeleteProductAsync(id);
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        private async Task<IEnumerable<SelectListItem>> getCategoriesForSelectList()
        {
            var categories = await _categoryService.GetCategoryListAsync();
            return categories.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() });
        }

        private async Task<PaginationProductViewModel> getPaginationProductViewModel(int pageNo, int categoryId, string search)
        {
            IEnumerable<ProductDisplayResponse> products;
            if (!string.IsNullOrEmpty(search))
            {
                products = await _productService.GetProductListByNameAsync(search);
            }
            else if (categoryId == 0)
            {
                products = await _productService.GetProductListAsync();
            }
            else
            {
                products = await _productService.GetProductListByCategoryAsync(categoryId);
            }

            var productsCount = products.Count();
            var productPerPage = 5;

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
