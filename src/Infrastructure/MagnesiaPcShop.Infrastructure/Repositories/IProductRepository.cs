using MagnesiaPcShop.Entities;
using System.Diagnostics.Contracts;

namespace MagnesiaPcShop.Infrastructure.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IList<Product>> GetProductListByCategoryAsync(int categoryId);
        IList<Product> GetProductListByCategory(int categoryId);
    }
}