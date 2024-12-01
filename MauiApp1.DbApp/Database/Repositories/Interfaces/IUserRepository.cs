using MauiApp1.DbApp.Database.Repositories.Base;
using MauiApp1.DbApp.Models;

namespace MauiApp1.DbApp.Database.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity?> GetByUsernameAsync(string username);
    }
}
