using Microsoft.AspNetCore.Identity;
using Mynewapp.Models;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Mynewapp.Security
{
    public class SHA256PasswordHasher : IPasswordHasher<ApplicationUser>
    {
        private const int SaltSize = 16;

        public string HashPassword(ApplicationUser user, string password)
        {
            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] combinedBytes = new byte[passwordBytes.Length + salt.Length];
            Buffer.BlockCopy(passwordBytes, 0, combinedBytes, 0, passwordBytes.Length);
            Buffer.BlockCopy(salt, 0, combinedBytes, passwordBytes.Length, salt.Length);

            byte[] hashBytes;
            using (var sha256 = SHA256.Create())
            {
                hashBytes = sha256.ComputeHash(combinedBytes);
            }

            byte[] hashWithSaltBytes = new byte[hashBytes.Length + salt.Length];
            Buffer.BlockCopy(hashBytes, 0, hashWithSaltBytes, 0, hashBytes.Length);
            Buffer.BlockCopy(salt, 0, hashWithSaltBytes, hashBytes.Length, salt.Length);

            return Convert.ToBase64String(hashWithSaltBytes);
        }

        public PasswordVerificationResult VerifyHashedPassword(ApplicationUser user, string hashedPassword, string providedPassword)
        {
            byte[] hashWithSaltBytes = Convert.FromBase64String(hashedPassword);
            int hashSizeInBytes = 32;
            byte[] hashBytes = new byte[hashSizeInBytes];
            byte[] saltBytes = new byte[hashWithSaltBytes.Length - hashSizeInBytes];

            Buffer.BlockCopy(hashWithSaltBytes, 0, hashBytes, 0, hashSizeInBytes);
            Buffer.BlockCopy(hashWithSaltBytes, hashSizeInBytes, saltBytes, 0, saltBytes.Length);

            byte[] providedPasswordBytes = Encoding.UTF8.GetBytes(providedPassword);
            byte[] combinedBytes = new byte[providedPasswordBytes.Length + saltBytes.Length];
            Buffer.BlockCopy(providedPasswordBytes, 0, combinedBytes, 0, providedPasswordBytes.Length);
            Buffer.BlockCopy(saltBytes, 0, combinedBytes, providedPasswordBytes.Length, saltBytes.Length);

            byte[] providedHashBytes;
            using (var sha256 = SHA256.Create())
            {
                providedHashBytes = sha256.ComputeHash(combinedBytes);
            }

            for (int i = 0; i < hashSizeInBytes; i++)
            {
                if (hashBytes[i] != providedHashBytes[i])
                {
                    return PasswordVerificationResult.Failed;
                }
            }

            return PasswordVerificationResult.Success;
        }
    }
}
