using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using RomanC.Alibaba.Facade.Encoder.Models;
using Microsoft.AspNetCore.WebUtilities;

namespace RomanC.Alibaba.Facade.Encoder.Services
{
    class DefaultEncoderService
        : IEncoderService
    {
        private const int IDX_MsgContent = 0;
        private const int IDX_MsgType    = 1;
        private const int IDX_MsgSign    = 2;

        private static readonly string[] Keys =
        {
            "logistics_interface",
            "msg_type",
            "data_digest"
        };

        private ISigningService _signingService = new CainiaoSigningService();

        // allows to unit test this class if needed
        public ISigningService SigningService
        {
            get => _signingService;
            set => _signingService = value ?? throw new ArgumentNullException(nameof(value), nameof(SigningService));
        }

        public CainiaoMessage Decode(string message)
        {
            if (string.IsNullOrWhiteSpace(message)) return CainiaoMessage.Empty;

            // parse the message as query string variables.
            NameValueCollection qscoll = HttpUtility.ParseQueryString(message);

            return new CainiaoMessage
            {
                MessageContentXml = qscoll[Keys[IDX_MsgContent]],
                MessageType       = qscoll[Keys[IDX_MsgType]],
                Signature         = qscoll[Keys[IDX_MsgSign]] 
            };
        }

        public async Task<string> Encode(string messageContentXml, string messageType, string secretKey,
            CancellationToken cancellationToken)
        {
            var sing = await _signingService.Sing(messageContentXml, secretKey, cancellationToken);

            var msgAsParams = new Dictionary<string, string>
            {
                {Keys[IDX_MsgContent], messageContentXml},
                {Keys[IDX_MsgType], messageType},
                {Keys[IDX_MsgSign], sing},
            };

            var res = QueryHelpers.AddQueryString("", msgAsParams);
            // skip first char because it is '?'
            return res.Substring(1, res.Length - 1);
        }
    }
}