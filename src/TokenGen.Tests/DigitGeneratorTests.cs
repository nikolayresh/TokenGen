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
                .WithUniqueChars(18)
                .NeverStartsWith('0');

            for (int i = 0; i < 1000; i++)
            {
                var token = TokenGenerator.Generate(options);
            }
        }
    }
}