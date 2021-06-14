using System.Threading;
using System.Threading.Tasks;

namespace RomanC.Alibaba.Facade.Encoder.Services
{
    public interface ISigningService
    {
        Task<string> Sing(string content, string secretKey, CancellationToken cancellationToken);
    }

    // no unit tests for this class due to Cainiao doesn't provide clear example
    // so there are no references.
}