namespace MauiApp1.DbApp.Models
{
    public class UserEntity
    {
        public static UserEntity Create(string name, string username, string passwordHash, string role)
        {
            return new UserEntity
            {
                Id = Guid.NewGuid(),
                Name = name,
                Username = username,
                PasswordHash = passwordHash,
                Role = role
            };
        }

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty; // Имя пользователя
        public string Username { get; set; } = string.Empty; // Логин пользователя
        public string PasswordHash { get; set; } = string.Empty; // Хэш пароля
        public string Role { get; set; } = string.Empty; // Роль пользователя

        public ICollection<OrderEntity> Orders { get; set; } = new List<OrderEntity>(); // Заказы пользователя
    }

}
