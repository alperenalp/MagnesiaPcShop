using MagnesiaPcShop.Entities;
using System.Diagnostics.Contracts;
using System.Linq.Expressions;

namespace MagnesiaPcShop.Infrastructure.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IList<Product>> GetProductListByCategoryAsync(int categoryId);
        Task<IList<Product>> GetProductListByNameAsync(string productName);

        IList<Product> GetProductListByCategory(int categoryId);
        IList<Product> GetProductListByName(string productName);

    }
}