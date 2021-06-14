using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using RomanC.Alibaba.Facade.Encoder.Models;

namespace RomanC.Alibaba.Facade.Encoder.Services
{
    // ReSharper disable once InconsistentNaming
    static class IEncoderServiceExtension
    {
        public static async Task<string> Encode(this IEncoderService service, EncodeViewModel model,
            CancellationToken cancellationToken)
        {
            if (null == service) throw new ArgumentNullException(nameof(service));
            if (null == model) throw new ArgumentNullException(nameof(model));

            var rawXml = RemoveNewLineAndPadding(model.MessageContentXml);

            return await service.Encode(rawXml, model.MessageType, model.SecretKey, cancellationToken);
        }

        public static string RemoveNewLineAndPadding(string input)
        {
            return Regex.Replace(input, @"\n|\s{2,}", "", RegexOptions.IgnoreCase | RegexOptions.Multiline);
        }
    }
}