using MagnesiaPcShop.Entities;

namespace MagnesiaPcShop.Mvc.Models
{
    public class ProductCollection
    {
        public List<ProductItem> ProductItems { get; set; } = new List<ProductItem>();
        public void ClearAll()=>ProductItems.Clear();
        public decimal TotalProductPrice() => ProductItems.Sum(p => p.Product.Price * p.Quantity);
        public int TotalProductCount() => ProductItems.Sum(p => p.Quantity);
        public void AddNewProduct(ProductItem request)
        {
            var product = ProductItems.FirstOrDefault(p => p.Product.Id == request.Product.Id);
            if (product != null)
            {
                product.Quantity += request.Quantity;
            }
            else
            {
                ProductItems.Add(request);
            }
        }
    }

    public class ProductItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public bool? ApplyCoupon { get; set; }
    }
}
