using MagnesiaPcShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace MagnesiaPcShop.Mvc.ViewComponents
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public CategoryMenuViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryService.GetCategoryList();
            return View(categories);
        }
    }
}
