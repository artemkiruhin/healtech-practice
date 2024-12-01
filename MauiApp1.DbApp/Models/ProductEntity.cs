namespace MauiApp1.DbApp.Models
{
    public class ProductEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty; // Название товара
        public decimal Price { get; set; } // Цена за единицу
        public int StockQuantity { get; set; } // Количество на складе

        public ICollection<OrderEntity> Orders { get; set; } = new List<OrderEntity>(); // Список заказов, содержащих этот товар

        public static ProductEntity Create(string name, decimal price, int stockQuantity)
        {
            return new ProductEntity
            {
                Id = Guid.NewGuid(),
                Name = name,
                Price = price,
                StockQuantity = stockQuantity
            };
        }
    }
}