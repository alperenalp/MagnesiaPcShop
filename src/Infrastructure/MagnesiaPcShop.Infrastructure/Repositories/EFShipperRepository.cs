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
    public class EFShipperRepository : IShipperRepository
    {
        private readonly MagnesiaPcDbContext _dbContext;

        public EFShipperRepository(MagnesiaPcDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Shipper entity)
        {
            _dbContext.Shippers.Add(entity);
            _dbContext.SaveChanges();
        }

        public async Task CreateAsync(Shipper entity)
        {
            await _dbContext.Shippers.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var shipper = _dbContext.Shippers.Find(id);
            _dbContext.Shippers.Remove(shipper);
            _dbContext.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var shipper = await _dbContext.Shippers.FindAsync(id);
            _dbContext.Shippers.Remove(shipper);
            await _dbContext.SaveChangesAsync();
        }

        public IList<Shipper> GetAll()
        {
            return _dbContext.Shippers.AsNoTracking().ToList();
        }

        public async Task<IList<Shipper>> GetAllAsync()
        {
            return await _dbContext.Shippers.AsNoTracking().ToListAsync();
        }

        public Shipper GetById(int id)
        {
            return _dbContext.Shippers.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public async Task<Shipper?> GetByIdAsync(int id)
        {
            return await _dbContext.Shippers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public bool IsExists(int id)
        {
            return _dbContext.Shippers.Any(x => x.Id == id);
        }

        public async Task<bool> IsExistsAsync(int id)
        {
            return await _dbContext.Shippers.AnyAsync(x => x.Id == id);
        }

        public void Update(Shipper entity)
        {
            _dbContext.Shippers.Update(entity);
            _dbContext.SaveChanges();
        }

        public async Task UpdateAsync(Shipper entity)
        {
            _dbContext.Shippers.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
