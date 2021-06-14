using FluentAssertions;
using NUnit.Framework;

namespace RomanC.Alibaba.Facade.Encoder.Services
{
    [TestFixture]
    public class IEncoderServiceExtensionTests
    {
        [Test]
        public void RemoveNewLineAndPadding()
        {
            // arrange
            const string arg = @"
            <address>
              <country>United States</country>
            </address>
            ";
            // act
            var actual = IEncoderServiceExtension.RemoveNewLineAndPadding(arg);
            // assert
            const string expected = "<address><country>United States</country></address>";
            actual.Should().BeEquivalentTo(expected);
        }

        #region Test Helpers

        private IEncoderServiceExtensionTestsFixture _fixture;

        [SetUp]
        public void SetUp()
        {
            _fixture = new IEncoderServiceExtensionTestsFixture();
        }

        [TearDown]
        public void TearDown()
        {
        }

        #endregion
    }

    class IEncoderServiceExtensionTestsFixture
    {
    }
}