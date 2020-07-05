using NUnit.Framework;
using TokenGen.Generator;

namespace TokenGen.Tests
{
    [TestFixture]
    public class DigitsTest
    {
        [Test]
        public void Test()
        {
            var options = new TokenOptions()
                .WithDigits()
                .WithLowerLetters()
                .WithLength(3)
                .WithDistinctionRate(100.0M);

            var token = TokenGenerator.Generate(options);
        }
    }
}