using MagnesiaPcShop.DataTransferObjects.Requests.Product;
using MagnesiaPcShop.DataTransferObjects.Responses.Product;

namespace MagnesiaPcShop.Services
{
    public interface IProductService
    {
        Task CreateProductAsync(CreateNewProductRequest request);
        Task UpdateProductAsync(UpdateProductRequest request);
        Task DeleteProductAsync(int id);
        Task<IEnumerable<ProductDisplayResponse>> GetProductListAsync();
        Task<ProductDisplayResponse> GetProductByIdAsync(int id);
       

        void CreateProduct(CreateNewProductRequest request);
        void UpdateProduct(UpdateProductRequest request);
        void DeleteProduct(int id);
        IEnumerable<ProductDisplayResponse> GetProductList();
        ProductDisplayResponse GetProductById(int id);
        
    }
}