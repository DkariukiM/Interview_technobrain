using System;
using System.Security.Cryptography;
using System.Text;

namespace Auth.Utilities
{
    public static class HashingUtility
    {
        public static string HashPassword(string password)
        {
            
            byte[] saltBytes = Convert.FromBase64String(salt);

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 10000))
            {
                byte[] hash = pbkdf2.GetBytes(32); // 32 bytes = 256 bits
                return Convert.ToBase64String(hash);
            }
        }

        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }
    }
}
