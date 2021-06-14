using System.ComponentModel.DataAnnotations;

namespace RomanC.Alibaba.Facade.Encoder.Models
{
    public class DecodeViewModel
    {
        [Required]
        public string Message { get; set; }
    }
}