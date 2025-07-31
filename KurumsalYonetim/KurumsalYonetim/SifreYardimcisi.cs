using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KurumsalYonetim
{
    public class SifreYardimcisi
    {

        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes); 
            }
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
