using System;
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
                .WithLength(6)
                .WithUniqueChars(6);

            var token = TokenGenerator.Generate(options);
        }
    }
}