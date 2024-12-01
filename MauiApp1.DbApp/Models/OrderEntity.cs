namespace MauiApp1.DbApp.Models
{

    public class OrderEntity
    {
        public static OrderEntity Create(Guid customerId, Guid productId, int quantity)
        {
            return new OrderEntity
            {
                Id = customerId,
                OrderDate = DateTime.UtcNow,
                CustomerId = customerId,
                ProductId = productId,
                Quantity = quantity
            };
        }

        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime OrderDate { get; set; } // Дата создания заказа

        public Guid CustomerId { get; set; } // ID клиента
        public UserEntity Customer { get; set; } = null!; // Ссылка на клиента

        public Guid ProductId { get; set; } // ID товара
        public ProductEntity Product { get; set; } = null!; // Ссылка на товар

        public int Quantity { get; set; } // Количество товара

        public decimal TotalPrice => Quantity * Product.Price; // Общая стоимость заказа
    }

}
