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
                .WithLength(7)
                .WithUniquenessRate(80.0M);

            var token = TokenGenerator.Generate(options);
        }
    }
}