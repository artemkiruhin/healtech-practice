﻿using System.Security.Cryptography;
using System.Text;

namespace MauiApp1.Front.Services
{
    public interface IHashService
    {
        string HashPassword(string password);
    }

    public class HashService : IHashService
    {
        public string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
