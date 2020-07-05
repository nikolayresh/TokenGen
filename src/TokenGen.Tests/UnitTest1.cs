using System;
using System.Collections;
using NUnit.Framework;

namespace TokenGen.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            int negative = -1;
            int result = negative & 0x7FFFFFFF;

            var arrNeg = new BitArray(new []{negative});
            var arr = new BitArray(new []{result});
        }
    }
}