using System.Threading;
using System.Threading.Tasks;
using RomanC.Alibaba.Facade.Encoder.Models;

namespace RomanC.Alibaba.Facade.Encoder.Services
{
    public interface IEncoderService
    {
        /// <summary>
        /// Parses raw HTTP request body into <see cref="CainiaoMessage"/> object.
        /// </summary>
        /// <param name="message">The raw HTML request.</param>
        /// <returns></returns>
        CainiaoMessage Decode(string message);

        /// <summary>
        /// Returns ready to use HTTP request body.
        /// </summary>
        /// <param name="messageContentXml">The message content to encode.</param>
        /// <param name="messageType">The message type.</param>
        /// <param name="secretKey">The secret key to sign message.</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<string> Encode(string messageContentXml, string messageType, string secretKey,
            CancellationToken cancellationToken);
    }
}