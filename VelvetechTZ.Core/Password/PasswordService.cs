using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;

namespace VelvetechTZ.Core.Password
{
    public class PasswordService : IPasswordService
    {
        public bool VerifyHashedPassword(string? hashedPassword, string? salt, string? providedPassword)
        {
            var providedHashed = HashPassword(providedPassword, Convert.FromBase64String(salt ?? string.Empty));
            return string.Equals(hashedPassword, providedHashed);
        }

        public (string hash, string salt) GetNewPassword(string? input)
        {
            var salt = GenerateSalt();
            var hashed = HashPassword(input, salt);
            return (hashed, Convert.ToBase64String(salt));
        }

        private static string HashPassword(string? input, byte[] salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(input, salt, KeyDerivationPrf.HMACSHA1, 10000, 256 / 8));
        }

        private static byte[] GenerateSalt()
        {
            var salt = new byte[128 / 8];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(salt);
            return salt;
        }
    }
}