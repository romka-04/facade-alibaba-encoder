using System;

namespace RomanC.Alibaba.Facade.Encoder.Models
{
    public record CainiaoMessage 
    {
        public static CainiaoMessage Empty { get; } = new();

        /// <summary>
        /// The main order of information. This expected to be XML serialized document.
        /// </summary>
        public string MessageContentXml { get; init; }
        /// <summary>
        /// Message type.
        /// </summary>
        public string MessageType { get; init; }
        /// <summary>
        /// Message signature.
        /// </summary>
        public string Signature { get; init; }
        /// <summary>
        /// Message Id.
        /// </summary>
        public string MessageId { get; init; }

        #region CTOR

        public CainiaoMessage()
        { }

        public CainiaoMessage(string messageContentXml, string messageType, string signature, string messageId)
        {
            MessageContentXml = messageContentXml;
            MessageType       = messageType;
            Signature         = signature;
            MessageId         = messageId;
        }

        #endregion
        
        public virtual bool Equals(CainiaoMessage other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(MessageContentXml, other.MessageContentXml, StringComparison.InvariantCultureIgnoreCase) &&
                   string.Equals(MessageType, other.MessageType, StringComparison.InvariantCultureIgnoreCase) &&
                   string.Equals(Signature, other.Signature, StringComparison.InvariantCultureIgnoreCase) &&
                   string.Equals(MessageId, other.MessageId, StringComparison.InvariantCultureIgnoreCase);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(MessageContentXml, StringComparer.InvariantCultureIgnoreCase);
            hashCode.Add(MessageType, StringComparer.InvariantCultureIgnoreCase);
            hashCode.Add(Signature, StringComparer.InvariantCultureIgnoreCase);
            hashCode.Add(MessageId, StringComparer.InvariantCultureIgnoreCase);
            return hashCode.ToHashCode();
        }
    }
}