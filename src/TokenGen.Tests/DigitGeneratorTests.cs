using NUnit.Framework;
using TokenGen.Generator;

namespace TokenGen.Tests
{
    [TestFixture]
    public class DigitGeneratorTests
    {
        [Test]
        public void Test()
        {
            var options = new TokenOptions()
                .WithDigits()
                .WithUpperLetters()
                .WithLength(18)
                .WithAllDistinctCharacters()
                .NeverStartsWith('0')
                .WithPrefix("GTX");

            for (int i = 0; i < 1000; i++)
            {
                var token = TokenGenerator.Generate(options);
            }
        }
    }
}