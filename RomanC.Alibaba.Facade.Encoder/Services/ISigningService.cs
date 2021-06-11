namespace RomanC.Alibaba.Facade.Encoder.Services
{
    public interface ISigningService
    {
        string Sing(string content, string secretKey);
    }

    // no unit tests for this class due to Cainiao doesn't provide clear example
    // so there are no references.
}