using MagnesiaPcShop.DataTransferObjects.Requests.Category;
using MagnesiaPcShop.DataTransferObjects.Responses.Category;
using MagnesiaPcShop.Entities;

namespace MagnesiaPcShop.Services
{
    public interface ICategoryService
    {
        Task CreateCategoryAsync(CreateNewCategoryRequest request);
        Task UpdateCategoryAsync(UpdateCategoryRequest request);
        Task DeleteProductAsync(int id);
        Task<IEnumerable<CategoryDisplayResponse>> GetCategoryListAsync();
        Task<UpdateCategoryRequest> GetCategoryForUpdateAsync(int id);
        Task<bool> IsCategoryExistsAsync(int id);

        void CreateCategory(CreateNewCategoryRequest request);
        void UpdateCategory(UpdateCategoryRequest request);
        void DeleteProduct(int id);
        IEnumerable<CategoryDisplayResponse> GetCategoryList();
        UpdateCategoryRequest GetCategoryForUpdate(int id);
        bool IsCategoryExists(int id);
    }
}