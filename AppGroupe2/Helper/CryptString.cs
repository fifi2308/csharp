using Org.BouncyCastle.Tls.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AppGroupe2.Helper
{
    /* public static class CryptString
      {
          public static string GetMd5Hash(string input)
          {
              StringBuilder sBuilder = new StringBuilder();
              using (MD5 md5Hash = MD5.Create())
              {
                  byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                  for (int i = 0; i < data.Length; i++)
                  {
                      sBuilder.Append(data[i].ToString("x2"));
                  }
              }
              return sBuilder.ToString();
          } 

          public static bool VerifyMd5Hash( string input, string hash)
          {
              // Hash the input.
              string hashOfInput = GetMd5Hash( input);
              // Create a StringComparer an compare the hashes.
              StringComparer comparer = StringComparer.OrdinalIgnoreCase;
              if (0 == comparer.Compare(hashOfInput, hash))
              {
                  return true;

              }

              else
              {
                  return false;
              }
          }

      }*/
    public static class CryptString
    {
        public static string GetMd5Hash(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                // Utiliser Encoding.ASCII ici
                byte[] data = md5Hash.ComputeHash(Encoding.ASCII.GetBytes(input));

                StringBuilder sBuilder = new StringBuilder();
                foreach (byte b in data)
                {
                    sBuilder.Append(b.ToString("x2")); // x2 pour un hexadécimal en minuscule
                }

                return sBuilder.ToString();
            }
        }

        public static bool VerifyMd5Hash(string input, string hash)
        {
            string hashOfInput = GetMd5Hash(input);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(hashOfInput, hash) == 0;
        }
    }
}
          
