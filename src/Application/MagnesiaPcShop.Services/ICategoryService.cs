using MagnesiaPcShop.DataTransferObjects.Responses.Category;

namespace MagnesiaPcShop.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDisplayResponse>> GetCategoryList();
    }
}