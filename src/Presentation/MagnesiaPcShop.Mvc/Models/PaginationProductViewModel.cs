using MagnesiaPcShop.DataTransferObjects.Responses.Product;

namespace MagnesiaPcShop.Mvc.Models
{
    public class PaginationProductViewModel
    {
        public IEnumerable<ProductDisplayResponse> Products { get; set; }
        public PaginationInfo PaginationInfo { get; set; }
    }
}
