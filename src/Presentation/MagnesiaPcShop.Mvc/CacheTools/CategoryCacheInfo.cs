using MagnesiaPcShop.DataTransferObjects.Responses.Category;
using MagnesiaPcShop.DataTransferObjects.Responses.Product;

namespace MagnesiaPcShop.Mvc.CacheTools
{
    public class CategoryCacheInfo
    {
        public IEnumerable<CategoryDisplayResponse> Categories { get; set; }
        public DateTime CacheTime { get; set; }
    }
}
