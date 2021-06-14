using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace RomanC.Alibaba.Facade.Encoder.Services
{
    [TestFixture]
    public class CainiaoSigningServiceTests
    {
        [Test]
        public async Task MD5_custom_implementation_compare_with_microsoft()
        {
            // arrange
            var arg = _fixture.CreateRandomString(256);
            // act
            var actual = await MD5_NetCoreEncrypt(arg);
            var expected = MD5_Legacy(arg);
            // assert
            actual.Should().BeEquivalentTo(expected);
        }

        private async Task<string> MD5_NetCoreEncrypt(string input)
        {
            var blob = await CainiaoSigningService.Md5Encrypt(input, CancellationToken.None);
            var res = Encoding.ASCII.GetString(blob);
            await TestContext.Out.WriteLineAsync($"Custom Impl: '{res}'");
            return res;
        }

        // https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.md5?redirectedfrom=MSDN&view=net-5.0
        public static string MD5_Legacy(string input)
        {
            // Use input string to calculate MD5 hash
            using MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }

            var res = sb.ToString();
            TestContext.Out.WriteLine($"Legacy: '{res}'");
            return res;
        }

        #region Test Helpers

        private CainiaoSigningServiceTestsFixture _fixture;

        [SetUp]
        public void SetUp()
        {
            _fixture = new CainiaoSigningServiceTestsFixture();
        }

        [TearDown]
        public void TearDown()
        {
        }

        #endregion
    }

    public class CainiaoSigningServiceTestsFixture
    {
        private Random _random = new();

        public string CreateRandomString(int length)
        {
            var sb = new StringBuilder(length);
            for (var i = 0; i < length; i++)
            {
                sb.Append(((char)(_random.Next(1, 83) + 33)).ToString());
            }

            var res = sb.ToString();
            TestContext.Out.WriteLine(res);
            return res;
        }
    }
}