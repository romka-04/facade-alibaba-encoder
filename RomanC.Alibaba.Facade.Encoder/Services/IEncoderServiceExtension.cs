using System;
using RomanC.Alibaba.Facade.Encoder.Models;

namespace RomanC.Alibaba.Facade.Encoder.Services
{
    // ReSharper disable once InconsistentNaming
    static class IEncoderServiceExtension
    {
        public static string Encode(this IEncoderService service, EncodeViewModel model)
        {
            if (null == service) throw new ArgumentNullException(nameof(service));
            if (null == model) throw new ArgumentNullException(nameof(model));

            return service.Encode(model.MessageContentXml, model.MessageType, model.SecretKey);
        }
    }
}