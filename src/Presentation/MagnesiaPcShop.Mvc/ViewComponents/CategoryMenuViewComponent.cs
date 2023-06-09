using MagnesiaPcShop.DataTransferObjects.Responses.Category;
using MagnesiaPcShop.Mvc.CacheTools;
using MagnesiaPcShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace MagnesiaPcShop.Mvc.ViewComponents
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly IMemoryCache _memoryCache;

        public CategoryMenuViewComponent(ICategoryService categoryService, IMemoryCache memoryCache)
        {
            _categoryService = categoryService;
            _memoryCache = memoryCache;
        }

        public IViewComponentResult Invoke()
        {
            var categories =  getCategoriesFromCacheOrDb();
            return View(categories);
        }

        private IEnumerable<CategoryDisplayResponse> getCategoriesFromCacheOrDb()
        {

            if (!_memoryCache.TryGetValue("allCategories", out CategoryCacheInfo categoryCacheInfo))
            {
                var options = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(1))
                    .SetPriority(CacheItemPriority.High);

                categoryCacheInfo = new CategoryCacheInfo
                {
                    CacheTime = DateTime.Now,
                    Categories = _categoryService.GetCategoryList()
            };

                _memoryCache.Set("allCategories", categoryCacheInfo, options);
            }

            return categoryCacheInfo.Categories;
        }
    }
}
