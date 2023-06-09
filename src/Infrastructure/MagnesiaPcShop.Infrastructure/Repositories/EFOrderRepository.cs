using MagnesiaPcShop.Infrastructure.Data;
using MagnesiaPcShop.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagnesiaPcShop.Infrastructure.Repositories
{
    public class EFOrderRepository : IOrderRepository
    {
        private readonly MagnesiaPcDbContext _dbContext;

        public EFOrderRepository(MagnesiaPcDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Order entity)
        {
            _dbContext.Orders.Add(entity);
            _dbContext.SaveChanges();
        }

        public async Task CreateAsync(Order entity)
        {
            await _dbContext.Orders.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var order = _dbContext.Orders.Find(id);
            _dbContext.Orders.Remove(order);
            _dbContext.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var order = await _dbContext.Orders.FindAsync(id);
            _dbContext.Orders.Remove(order);
            await _dbContext.SaveChangesAsync();
        }

        public IList<Order> GetAll()
        {
            return _dbContext.Orders.AsNoTracking().ToList();
        }

        public async Task<IList<Order>> GetAllAsync()
        {
            return await _dbContext.Orders.AsNoTracking().ToListAsync();
        }

        public Order GetById(int id)
        {
            return _dbContext.Orders.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _dbContext.Orders.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public bool IsExists(int id)
        {
            return _dbContext.Orders.Any(x => x.Id == id);
        }

        public async Task<bool> IsExistsAsync(int id)
        {
            return await _dbContext.Orders.AnyAsync(x => x.Id == id);
        }

        public void Update(Order entity)
        {
            _dbContext.Orders.Update(entity);
            _dbContext.SaveChanges();
        }

        public async Task UpdateAsync(Order entity)
        {
            _dbContext.Orders.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
