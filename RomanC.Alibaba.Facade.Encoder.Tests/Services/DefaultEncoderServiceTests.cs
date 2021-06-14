using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using RomanC.Alibaba.Facade.Encoder.Models;

namespace RomanC.Alibaba.Facade.Encoder.Services
{
    [TestFixture]
    public class DefaultEncoderServiceTests
    {
        [TestCase(null)]
        [TestCase("")]
        public void Decode_message_null_or_empty_should_return_empty_result(string arg)
        {
            // arrange
            var sut = _fixture.CreateSut();
            // act
            var actual = sut.Decode(arg);
            // assert
            actual.Should().NotBeNull();
            var expected = CainiaoMessage.Empty;
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void Decode_ok_message_should_properly_parse()
        {
            // arrange
            var arg = _fixture.CreateRawCainioMessage();
            var sut = _fixture.CreateSut();
            // act
            var actual = sut.Decode(arg);
            // assert
            actual.Should().NotBeNull();
            var expected = _fixture.CreateExpectedCainiaoMessage();
            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public async Task Encode_good_args_should_create_proper_result()
        {
            // arrange
            var mcx = "<order>helloworld</order>";
            var mt  = "LOGISTICS_BATCH_SEND";
            var sk  = "any";
            var sut = (DefaultEncoderService) _fixture.CreateSut();
            //sut.SigningService = Mock.Of<ISigningService>(
            //    x => x.Sing(It.IsAny<string>(), It.IsAny<string>(), TODO) == "7gT/HmFFTflwfm/3LOKdmQ=="
            //);
            // act
            var actual = await sut.Encode(mcx, mt, sk, CancellationToken.None);
            // assert
            var expected = _fixture.CreateRawCainioMessage();
            actual.Should().BeEquivalentTo(expected);

        }

        #region Test Helpers

        private DefaultEncoderServiceTestsFixture _fixture;

        [SetUp]
        public void SetUp()
        {
            _fixture = new DefaultEncoderServiceTestsFixture();
        }

        [TearDown]
        public void TearDown()
        {
        }

        #endregion
    }

    public class DefaultEncoderServiceTestsFixture
    {
        public string CreateRawCainioMessage()
        {
            return @"logistics_interface=%3Corder%3Ehelloworld%3C%2Forder%3E&msg_type=LOGISTICS_BATCH_SEND&data_digest=7gT/HmFFTflwfm/3LOKdmQ==";
        }

        public IEncoderService CreateSut()
        {
            return new DefaultEncoderService();
        }

        public CainiaoMessage CreateExpectedCainiaoMessage()
        {
            return new()
            {
                MessageContentXml = "<order>helloworld</order>",
                MessageType       = "LOGISTICS_BATCH_SEND",
                MessageId         = null,
                Signature         = "7gT/HmFFTflwfm/3LOKdmQ=="
            };
        }
    }
}