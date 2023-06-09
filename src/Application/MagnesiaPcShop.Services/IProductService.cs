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
        Task<ProductDisplayResponse> GetProductByIdAsync(int id);
        Task<UpdateProductRequest> GetProductForUpdateAsync(int id);
        Task<IEnumerable<ProductDisplayResponse>> GetProductListAsync();
        Task<IEnumerable<ProductDisplayResponse>> GetProductListByCategoryAsync(int categoryId);
        Task<IEnumerable<ProductDisplayResponse>> GetProductListByNameAsync(string productName);
        Task<bool> IsProductExistsAsync(int id);


        void CreateProduct(CreateNewProductRequest request);
        void UpdateProduct(UpdateProductRequest request);
        void DeleteProduct(int id);
        ProductDisplayResponse GetProductById(int id);
        UpdateProductRequest GetProductForUpdate(int id);
        IEnumerable<ProductDisplayResponse> GetProductList();
        IEnumerable<ProductDisplayResponse> GetProductListByCategory(int categoryId);
        IEnumerable<ProductDisplayResponse> GetProductListByName(string productName);
        bool IsProductExists(int id);
    }
}