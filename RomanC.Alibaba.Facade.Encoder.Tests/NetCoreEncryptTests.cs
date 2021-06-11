using System;
using System.Security.Cryptography;
using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace RomanC.Alibaba.Facade.Encoder
{
    [TestFixture]
    public class NetCoreEncryptTests
    {
        [Test]
        public void MD5_compare_with_microsoft()
        {
            // arrange
            var arg = _fixture.CreateRandomString(256);
            // act
            var actual = MD5_NetCoreEncrypt(arg);
            var expected = MD5_Legacy(arg);
            // assert
            actual.Should().BeEquivalentTo(expected);
        }

        private string MD5_NetCoreEncrypt(string input)
        {
            // implement using 
            // https://stackoverflow.com/a/53719198/2903893

            throw new NotImplementedException();
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
            TestContext.Out.WriteLine($"NETCore.Encrypt: '{res}'");
            return res;
        }

        #region Test Helpers

        private NetCoreEncryptTestsFixture _fixture;

        [SetUp]
        public void SetUp()
        {
            _fixture = new NetCoreEncryptTestsFixture();
        }

        [TearDown]
        public void TearDown()
        {
        }

        #endregion
    }

    public class NetCoreEncryptTestsFixture
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