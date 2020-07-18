﻿using NUnit.Framework;
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
                .WithLength(10);

            var token = TokenGenerator.Generate(options);
        }
    }
}