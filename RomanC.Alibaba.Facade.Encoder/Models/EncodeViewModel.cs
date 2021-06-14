using System.ComponentModel.DataAnnotations;

namespace RomanC.Alibaba.Facade.Encoder.Models
{
    public class EncodeViewModel
    {
        [Required]
        public string MessageContentXml { get; set; }
        [Required]
        public string MessageType { get; set; }
        public string SecretKey { get; set; }
    }
}