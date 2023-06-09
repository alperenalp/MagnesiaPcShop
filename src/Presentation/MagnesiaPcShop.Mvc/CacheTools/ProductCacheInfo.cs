using MagnesiaPcShop.DataTransferObjects.Responses.Product;

namespace MagnesiaPcShop.Mvc.CacheTools
{
    public class ProductCacheInfo
    {
        public IEnumerable<ProductDisplayResponse> Products { get; set; }
        public DateTime CacheTime { get; set; }
    }
}
