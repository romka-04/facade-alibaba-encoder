using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RomanC.Alibaba.Facade.Encoder.Services.Cryptography;

namespace RomanC.Alibaba.Facade.Encoder.Services
{
    class CainiaoSigningService
        : ISigningService
    {
        public async Task<string> Sing(string content, string secretKey, CancellationToken cancellationToken)
        {
            byte[] blob   = await Md5Encrypt(content + secretKey, cancellationToken);
            string result = Base64Encrypt(blob);
            return result;
        }

        public static async Task<byte[]> Md5Encrypt(string text, CancellationToken cancellationToken)
        {
            if (null == text)
            {
                throw new NullReferenceException("Attempt to encode null text");
            }

            // MD5 class implementation returns result in MD5ChangedEventArgs event
            // so its required to wait until the event is fired by MD5.
            // I'm using following implementation that shouldn't block UI or other functionality.
            var tcs = new TaskCompletionSource<bool>();

            // main functionality
            string res = null;
            var md5 = new MD5();
            md5.OnValueChanged += (_, changed) =>
            {
                res = changed.FingerPrint;
                tcs.TrySetResult(true); // finalizes task 
            };
            md5.Value = text; // initiates MD5 calculation

            // it would wait for the required event raising 2sec or until cancellation token completed 
            await Task.WhenAny(tcs.Task, Task.Delay(2000, cancellationToken));
            if (!tcs.Task.IsCompleted) 
                throw new Exception("Unable to retrieve MD5 fingerprint from the string.");

            return Encoding.ASCII.GetBytes(res);
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