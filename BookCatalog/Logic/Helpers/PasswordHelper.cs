using System;
using System.Security.Cryptography;
using System.Text;

namespace BookCatalog.Logic.Helpers
{
    public static class PasswordHelper
    {
        public static string HashPassword(string password)
        {   
            byte[] salt = RandomNumberGenerator.GetBytes(16);

            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] combined = new byte[passwordBytes.Length + salt.Length];
            Buffer.BlockCopy(passwordBytes, 0, combined, 0, passwordBytes.Length);
            Buffer.BlockCopy(salt, 0, combined, passwordBytes.Length, salt.Length);

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(combined);

                byte[] result = new byte[salt.Length + hash.Length];
                Buffer.BlockCopy(salt, 0, result, 0, salt.Length);
                Buffer.BlockCopy(hash, 0, result, salt.Length, hash.Length);

                return Convert.ToBase64String(result);
            }
        }

        public static bool VerifyPassword(string password, string storedHash)
        {
            byte[] hashBytes = Convert.FromBase64String(storedHash);

            byte[] salt = new byte[16];
            Buffer.BlockCopy(hashBytes, 0, salt, 0, salt.Length);

            byte[] storedHashBytes = new byte[hashBytes.Length - salt.Length];
            Buffer.BlockCopy(hashBytes, salt.Length, storedHashBytes, 0, storedHashBytes.Length);

            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] combined = new byte[passwordBytes.Length + salt.Length];
            Buffer.BlockCopy(passwordBytes, 0, combined, 0, passwordBytes.Length);
            Buffer.BlockCopy(salt, 0, combined, passwordBytes.Length, salt.Length);

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] computedHash = sha256.ComputeHash(combined);

                return CompareBytes(computedHash, storedHashBytes);
            }
        }

        private static bool CompareBytes(byte[] a, byte[] b)
        {
            if (a.Length != b.Length) return false;

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i]) return false;
            }
            return true;
        }
    }
}