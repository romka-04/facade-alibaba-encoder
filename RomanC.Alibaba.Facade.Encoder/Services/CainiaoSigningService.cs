using System;
using System.Text;

namespace RomanC.Alibaba.Facade.Encoder.Services
{
    class CainiaoSigningService
        : ISigningService
    {
        public string Sing(string content, string secretKey)
        {
            byte[] blob   = Md5Encrypt(content + secretKey);
            string result = Base64Encrypt(blob);
            return result;
        }

        private static byte[] Md5Encrypt(string text)
        {
            if (null == text)
            {
                throw new NullReferenceException("Attempt to encode null text");
            }

            throw new NotImplementedException("Platform not supported exception in WASP.");
            //MD5 md5 = new MD5CryptoServiceProvider();
            //md5.ComputeHash(Encoding.UTF8.GetBytes(text));

            //byte[] result = md5.Hash;
            //return result;
        }

        private static string Base64Encrypt(byte[] blob)
        {
            if (null == blob)
            {
                throw new NullReferenceException("Attempt to encode null text");
            }
            string result = Convert.ToBase64String(blob);
            return result;
        }
    }
}