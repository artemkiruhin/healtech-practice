using MauiApp1.DbApp.Database.Repositories.Base;
using MauiApp1.DbApp.Models;

namespace MauiApp1.DbApp.Database.Repositories.Interfaces
{
    public interface IProductRepository : IRepository<ProductEntity>
    {
        Task<IEnumerable<ProductEntity>> GetByStockAvailabilityAsync(int minStock);
    }
}
