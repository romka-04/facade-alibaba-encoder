using System;
using System.Runtime.Serialization;

namespace RomanC.Alibaba.Facade.Encoder.Services
{
    /// <summary>
    /// Basic exception for all cases when the app fails to decode Cainiao request.
    /// </summary>
    [Serializable]
    public class UnableDecodeException
        : Exception
    {
        public UnableDecodeException()
        {
        }

        public UnableDecodeException(string? message) : base(message)
        {
        }

        public UnableDecodeException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UnableDecodeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}