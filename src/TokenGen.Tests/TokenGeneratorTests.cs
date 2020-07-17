using System;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using TokenGen.Generator;

namespace TokenGen.Tests
{
    [TestFixture]
    public class TokenGeneratorTests
    {
        [Test]
        public void method_Generate_throws_ArgumentNullException_if_arg_is_null()
        {
            IOptions<TokenOptions> optionsAccessor = null;
            Assert.Throws<ArgumentNullException>(() => TokenGenerator.Generate(optionsAccessor));
        }
    }
}