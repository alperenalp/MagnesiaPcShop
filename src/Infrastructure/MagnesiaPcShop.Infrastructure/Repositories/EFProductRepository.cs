using MagnesiaPcShop.Infrastructure.Data;
using MagnesiaPcShop.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace MagnesiaPcShop.Infrastructure.Repositories
{
    public class EFProductRepository : IProductRepository
    {
        private readonly MagnesiaPcDbContext _dbContext;

        public EFProductRepository(MagnesiaPcDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Product entity)
        {
            _dbContext.Products.Add(entity);
            _dbContext.SaveChanges();
        }

        public async Task CreateAsync(Product entity)
        {
            await _dbContext.Products.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var product = _dbContext.Products.Find(id);
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }

        public IList<Product> GetAll()
        {
            return _dbContext.Products.AsNoTracking().ToList();
        }

        public async Task<IList<Product>> GetAllAsync()
        {
            return await _dbContext.Products.AsNoTracking().ToListAsync();
        }

        public Product GetById(int id)
        {
            return _dbContext.Products.AsNoTracking().SingleOrDefault(x => x.Id == id);
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _dbContext.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public IList<Product> GetProductListByCategory(int categoryId)
        {
            return _dbContext.Products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public async Task<IList<Product>> GetProductListByCategoryAsync(int categoryId)
        {
            return await _dbContext.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
        }

        public IList<Product> GetProductListByName(string productName)
        {
            return _dbContext.Products.Where(x=>x.Name.Contains(productName)).ToList();
        }

        public async Task<IList<Product>> GetProductListByNameAsync(string productName)
        {
            return await _dbContext.Products.Where(x => x.Name.Contains(productName)).ToListAsync();
        }

        public bool IsExists(int id)
        {
            return _dbContext.Products.Any(x => x.Id == id);
        }

        public async Task<bool> IsExistsAsync(int id)
        {
            return await _dbContext.Products.AnyAsync(x => x.Id == id);
        }

        public void Update(Product entity)
        {
            _dbContext.Products.Update(entity);
            _dbContext.SaveChanges();
        }

        public async Task UpdateAsync(Product entity)
        {
            _dbContext.Products.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
