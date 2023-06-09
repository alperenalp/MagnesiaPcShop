using MagnesiaPcShop.DataTransferObjects.Requests.Category;
using MagnesiaPcShop.DataTransferObjects.Requests.Product;
using MagnesiaPcShop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace MagnesiaPcShop.Mvc.Controllers
{
    [Authorize(Roles = "Admin,Editor")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetCategoryListAsync();
            return View(categories);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNewCategoryRequest request)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.CreateCategoryAsync(request);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryService.GetCategoryForUpdateAsync(id);
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, UpdateCategoryRequest request)
        {
            var isCategoryExists = _categoryService.IsCategoryExists(id);
            if (isCategoryExists)
            {
                if (ModelState.IsValid)
                {
                    await _categoryService.UpdateCategoryAsync(request);
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            return NotFound();

        }

        public async Task<IActionResult> Delete(int id)
        {
            var isCategoryExists = _categoryService.IsCategoryExists(id);
            if (isCategoryExists)
            {
                await _categoryService.DeleteProductAsync(id);
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

    }
}
