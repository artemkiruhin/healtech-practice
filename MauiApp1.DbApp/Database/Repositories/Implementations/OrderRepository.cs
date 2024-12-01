using MauiApp1.DbApp.Database.Repositories.Base;
using MauiApp1.DbApp.Database.Repositories.Interfaces;
using MauiApp1.DbApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MauiApp1.DbApp.Database.Repositories.Implementations
{
    public class OrderRepository : Repository<OrderEntity>, IOrderRepository
    {
        public OrderRepository(HealtechDbContext context) : base(context) { }

        public async Task<IEnumerable<OrderEntity>> GetOrdersByCustomerIdAsync(Guid customerId)
        {
            return await _dbSet
                .Include(o => o.Customer)
                .Include(o => o.Product)
                .Where(o => o.CustomerId == customerId)
                .ToListAsync();
        }
    }
}
