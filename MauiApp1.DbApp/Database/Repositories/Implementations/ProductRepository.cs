using MauiApp1.DbApp.Database.Repositories.Base;
using MauiApp1.DbApp.Database.Repositories.Interfaces;
using MauiApp1.DbApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MauiApp1.DbApp.Database.Repositories.Implementations
{
    public class ProductRepository : Repository<ProductEntity>, IProductRepository
    {
        public ProductRepository(HealtechDbContext context) : base(context) { }

        public async Task<IEnumerable<ProductEntity>> GetByStockAvailabilityAsync(int minStock)
        {
            return await _dbSet.Where(p => p.StockQuantity >= minStock).ToListAsync();
        }
    }
}
