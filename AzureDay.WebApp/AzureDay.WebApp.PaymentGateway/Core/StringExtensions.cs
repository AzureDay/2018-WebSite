using System.Security.Cryptography;
using System.Text;

namespace AzureDay.WebApp.PaymentGateway.Core
{
    public static class StringExtensions
    {
        /// <summary>
        /// Compute Md5 hash code
        /// </summary>
        /// <param name="input">Source string</param>
        /// <returns>Md5 in string</returns>
        public static string GetMd5Hash(this string input)
        {
            using (var md5Hash = MD5.Create())
            {
                var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sBuilder = new StringBuilder();
                for (var i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }
    }
}
