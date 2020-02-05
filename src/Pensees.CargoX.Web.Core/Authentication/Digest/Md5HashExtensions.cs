using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Pensees.CargoX.Authentication.Digest
{
    public static class Md5HashExtensions
    {
        public static string ToMd5Hash(this string input) => Md5Helper.Encrypt(input);
    }

    public class Md5Helper
    {
        public static string Encrypt(string plainText) => Encrypt(plainText, Encoding.UTF8);

        public static string Encrypt(string plainText, Encoding encoding)
        {
            var bytes = encoding.GetBytes(plainText);
            return Encrypt(bytes);
        }

        public static string Encrypt(byte[] bytes)
        {
            using (var md5 = MD5.Create())
            {
                var hash = md5.ComputeHash(bytes);
                return FromHash(hash);
            }
        }

        private static string FromHash(byte[] hash)
        {
            var sb = new StringBuilder();
            foreach (var t in hash)
            {
                sb.Append(t.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
