using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace FoxSky.TeachApp.BO
{
    public class User
    {
        public int UserId { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }

        public List<Word> Words { get; set; }

        public static string GetPasswordHash(string password)
        {
            string hash = null;

            if (!string.IsNullOrEmpty(password))
            {
                MD5 cryptoService = new MD5CryptoServiceProvider();

                cryptoService.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));
                byte[] inputBytes = cryptoService.Hash;
                inputBytes = cryptoService.ComputeHash(inputBytes);
                return BitConverter.ToString(inputBytes).Replace("-", "");
            }

            return hash;
        }
    }
}
