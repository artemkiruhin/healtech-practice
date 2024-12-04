namespace MauiApp1.DbApp.Models.Dtos
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty; // Product name
        public decimal Price { get; set; } // Price per unit
        public int StockQuantity { get; set; } // Quantity in stock
    }
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty; // User name
        public string Username { get; set; } = string.Empty; // User login
        public string Role { get; set; } = string.Empty; // User role
    }
    public class OrderDto
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; } // Order creation date
        public Guid CustomerId { get; set; } // Customer ID
        public string CustomerUsername { get; set; }
        public Guid ProductId { get; set; } // Product ID
        public string ProductName { get; set; }
        public int Quantity { get; set; } // Product quantity
        public decimal TotalPrice { get; set; } // Total order price
    }

}
