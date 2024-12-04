namespace MauiApp1.DbApp.Models
{
    public class OrderEntity
    {
        public static OrderEntity Create(Guid customerId, Guid productId, int quantity, decimal productPrice)
        {
            return new OrderEntity
            {
                Id = Guid.NewGuid(),
                OrderDate = DateTime.UtcNow,
                CustomerId = customerId,
                ProductId = productId,
                Quantity = quantity,
                TotalPrice = quantity * productPrice // Рассчитываем общую стоимость при создании
            };
        }

        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime OrderDate { get; set; } // Дата создания заказа

        public Guid CustomerId { get; set; } // ID клиента
        public UserEntity Customer { get; set; } = null!; // Ссылка на клиента

        public Guid ProductId { get; set; } // ID товара
        public ProductEntity Product { get; set; } = null!; // Ссылка на товар

        public int Quantity { get; set; } // Количество товара

        public decimal TotalPrice { get; set; } // Общая стоимость заказа, сохраняется в БД
    }
}
