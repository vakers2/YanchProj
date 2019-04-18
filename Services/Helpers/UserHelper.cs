using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Services
{
    public static class UserHelper
    {
        public static string ComputePasswordHash(string password)
        {
            var builder = new StringBuilder();
            using (var sha256Hash = SHA256.Create())
            {
                var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                foreach (var t in bytes)
                {
                    builder.Append(t.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
