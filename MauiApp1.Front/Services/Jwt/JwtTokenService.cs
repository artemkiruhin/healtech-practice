namespace MauiApp1.Front.Services.Jwt
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "jwt_token.txt");

        /// <summary>
        /// Сохраняет JWT токен в файл.
        /// </summary>
        /// <param name="token">JWT токен</param>
        public void SaveToken(string token)
        {
            try
            {
                File.WriteAllText(FilePath, token);
                Console.WriteLine("Токен успешно сохранён.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении токена: {ex.Message}");
            }
        }

        /// <summary>
        /// Читает JWT токен из файла.
        /// </summary>
        /// <returns>JWT токен</returns>
        public string ReadToken()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    string token = File.ReadAllText(FilePath);
                    Console.WriteLine("Токен успешно прочитан.");
                    return token;
                }
                else
                {
                    Console.WriteLine("Файл с токеном не найден.");
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении токена: {ex.Message}");
                return string.Empty;
            }
        }

        /// <summary>
        /// Удаляет файл с JWT токеном.
        /// </summary>
        public void DeleteToken()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    File.Delete(FilePath);
                    Console.WriteLine("Файл с токеном успешно удалён.");
                }
                else
                {
                    Console.WriteLine("Файл с токеном не найден для удаления.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при удалении токена: {ex.Message}");
            }
        }
    }
}
