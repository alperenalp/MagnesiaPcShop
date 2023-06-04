using MagnesiaPcShop.DataTransferObjects.Requests.Product;
using MagnesiaPcShop.DataTransferObjects.Responses.Category;
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
        Task<IEnumerable<ProductDisplayResponse>> GetProductListByCategoryAsync(int id);

        void CreateProduct(CreateNewProductRequest request);
        void UpdateProduct(UpdateProductRequest request);
        void DeleteProduct(int id);
        IEnumerable<ProductDisplayResponse> GetProductList();
        ProductDisplayResponse GetProductById(int id);
        IEnumerable<ProductDisplayResponse> GetProductListByCategory(int id);

    }
}