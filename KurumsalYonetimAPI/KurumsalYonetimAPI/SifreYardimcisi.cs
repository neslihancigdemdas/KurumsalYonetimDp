using System.Security.Cryptography;
using System;
using System.Text;

namespace KurumsalYonetimAPI.Helpers
{
    public class SifreYardimcisi
    {
        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            RandomNumberGenerator.Fill(saltBytes);
            return Convert.ToBase64String(saltBytes);
        }

        public static string HashSifre(string sifre, string salt)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                string saltedPassword = sifre + salt;
                byte[] saltedBytes = Encoding.UTF8.GetBytes(saltedPassword); 
                byte[] hashBytes = sha256.ComputeHash(saltedBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }
    }
}
