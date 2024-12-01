using MauiApp1.DbApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace MauiApp1.DbApp
{
    public class HealtechDbContext : DbContext
    {
        // DbSet для каждой сущности
        public DbSet<UserEntity> Users { get; set; } = null!;
        public DbSet<ProductEntity> Products { get; set; } = null!;
        public DbSet<OrderEntity> Orders { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Database=healtech;Username=postgres;Password=root");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Конфигурация сущностей
            ConfigureUserEntity(modelBuilder);
            ConfigureProductEntity(modelBuilder);
            ConfigureOrderEntity(modelBuilder);
            SeedData(modelBuilder);
        }

        private void ConfigureUserEntity(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<UserEntity>();

            entity.ToTable("Users"); // Имя таблицы
            entity.HasKey(u => u.Id); // Первичный ключ

            entity.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasIndex(u => u.Username)
                .IsUnique();

            entity.Property(u => u.PasswordHash)
                .IsRequired();

            entity.Property(u => u.Role)
                .IsRequired();

            // Связь User -> Orders
            entity.HasMany(u => u.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        private void ConfigureProductEntity(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<ProductEntity>();

            entity.ToTable("Products"); // Имя таблицы
            entity.HasKey(p => p.Id); // Первичный ключ

            entity.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(p => p.Price)
                .IsRequired();

            entity.Property(p => p.StockQuantity)
                .IsRequired();

            // Связь Product -> Orders
            entity.HasMany(p => p.Orders)
                .WithOne(o => o.Product)
                .HasForeignKey(o => o.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void ConfigureOrderEntity(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<OrderEntity>();

            entity.ToTable("Orders"); // Имя таблицы
            entity.HasKey(o => o.Id); // Первичный ключ

            entity.Property(o => o.OrderDate)
                .IsRequired();

            entity.Property(o => o.Quantity)
                .IsRequired();

            // Навигационные свойства Customer и Product
            entity.HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(o => o.Product)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Генерация идентификаторов для связи
            var customer1Id = Guid.NewGuid();
            var employee1Id = Guid.NewGuid();
            var product1Id = Guid.NewGuid();
            var product2Id = Guid.NewGuid();

            // Seed Users
            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    Id = customer1Id,
                    Name = "John Doe",
                    Username = "customer1",
                    // SHA256 hash of "CustomerPass123!"
                    PasswordHash = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8",
                    Role = "Customer"
                },
                new UserEntity
                {
                    Id = employee1Id,
                    Name = "Jane Smith",
                    Username = "employee1",
                    // SHA256 hash of "EmployeeSecure456!"
                    PasswordHash = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8",
                    Role = "Employee"
                }
            );

            // Seed Products
            modelBuilder.Entity<ProductEntity>().HasData(
                new ProductEntity
                {
                    Id = product1Id,
                    Name = "Health Tracker Device",
                    Price = 129.99m,
                    StockQuantity = 100
                },
                new ProductEntity
                {
                    Id = product2Id,
                    Name = "Fitness Smartwatch",
                    Price = 199.99m,
                    StockQuantity = 50
                }
            );

            // Seed Orders
            modelBuilder.Entity<OrderEntity>().HasData(
                new OrderEntity
                {
                    Id = Guid.NewGuid(),
                    CustomerId = customer1Id,
                    ProductId = product1Id,
                    Quantity = 1,
                    OrderDate = DateTime.UtcNow
                },
                new OrderEntity
                {
                    Id = Guid.NewGuid(),
                    CustomerId = customer1Id,
                    ProductId = product2Id,
                    Quantity = 2,
                    OrderDate = DateTime.UtcNow.AddDays(-1)
                }
            );
        }

    }
}
