using MauiApp1.DbApp;
using MauiApp1.DbApp.Database.Repositories.Base;
using MauiApp1.DbApp.Database.Repositories.Interfaces;
using MauiApp1.DbApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MauiApp1.DbApp.Database.Repositories.Implementations
{
    public class UserRepository : Repository<UserEntity>, IUserRepository
    {
        public UserRepository(HealtechDbContext context) : base(context) { }

        public async Task<UserEntity?> GetByUsernameAsync(string username)
        {
            return await _dbSet.FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
