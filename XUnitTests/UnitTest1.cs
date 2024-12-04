using MauiApp1.DbApp.Database.Repositories.Implementations;
using MauiApp1.DbApp.Models;
using MauiApp1.DbApp;
using Microsoft.EntityFrameworkCore;

namespace XUnitTests
{
    public class UserRepositoryTests : IDisposable
    {
        private readonly HealtechDbContext _context;
        private readonly UserRepository _repository;

        public UserRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<HealtechDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new HealtechDbContext(options);
            _repository = new UserRepository(_context);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Fact]
        public async Task AddUserAsync_ShouldAddUserToDatabase()
        {
            // Arrange
            var id = Guid.NewGuid();
            var user = new UserEntity
            {
                Id = id,
                Name = "Test User",
                Username = "testuser",
                PasswordHash = "hash123",
                Role = "Customer"
            };

            // Act
            await _repository.AddAsync(user);
            var addedUser = await _repository.GetByIdAsync(id);

            // Assert
            Assert.NotNull(addedUser);
            Assert.Equal(1, await _context.Users.CountAsync());
        }

        [Fact]
        public async Task GetByUsernameAsync_NonExistingUser_ShouldReturnNull()
        {
            // Act
            var retrievedUser = await _repository.GetByUsernameAsync("nonexistentuser");

            // Assert
            Assert.Null(retrievedUser);
        }

        [Fact]
        public async Task GetByUsernameAsync_ExistingUser_ShouldReturnUser()
        {
            // Arrange
            var user = new UserEntity
            {
                Id = Guid.NewGuid(),
                Name = "Test User",
                Username = "testuser",
                PasswordHash = "hash123",
                Role = "Customer"
            };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            // Act
            var retrievedUser = await _repository.GetByUsernameAsync("testuser");

            // Assert
            Assert.NotNull(retrievedUser);
            Assert.Equal(user.Username, retrievedUser.Username);
        }
    }

    public class ProductRepositoryTests : IDisposable
    {
        private readonly HealtechDbContext _context;
        private readonly ProductRepository _repository;

        public ProductRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<HealtechDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new HealtechDbContext(options);
            _repository = new ProductRepository(_context);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Fact]
        public async Task GetProductsByName_ShouldReturnCorrectProducts()
        {
            // Arrange
            var products = new[]
            {
                new ProductEntity { Id = Guid.NewGuid(), Name = "Product1", Price = 50, StockQuantity = 10 },
                new ProductEntity { Id = Guid.NewGuid(), Name = "Product2", Price = 100, StockQuantity = 20 },
                new ProductEntity { Id = Guid.NewGuid(), Name = "Product3", Price = 150, StockQuantity = 30 }
            };
            await _context.Products.AddRangeAsync(products);
            await _context.SaveChangesAsync();

            // Act
            var all = await _repository.GetAllAsync();
            var result = all.Where(x => x.Name == "Product2").ToList();

            // Assert
            Assert.Single(result);
            Assert.Equal("Product2", result[0].Name);
        }
    }
}
