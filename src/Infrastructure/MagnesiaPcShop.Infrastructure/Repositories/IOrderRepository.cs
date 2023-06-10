using MagnesiaPcShop.Entities;

namespace MagnesiaPcShop.Infrastructure.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<int> CreateOrderAsync(Order order);
    }
}