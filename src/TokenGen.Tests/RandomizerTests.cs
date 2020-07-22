using System;
using NUnit.Framework;
using Randomizer = TokenGen.Generator.Randomizer;

namespace TokenGen.Tests
{
    [TestFixture]
    public class RandomizerTests
    {
        [Test]
        public void method_NextTuples_returns_correct_count_of_tuples()
        {
            int length;
            Tuple<int, int>[] tuples;

            length = 327;
            tuples = Randomizer.NextTuples(length);
            Assert.NotNull(tuples);
            Assert.AreEqual(327, tuples.Length);

            length = 133;
            tuples = Randomizer.NextTuples(length);
            Assert.NotNull(tuples);
            Assert.AreEqual(133, tuples.Length);

            length = 100;
            tuples = Randomizer.NextTuples(length);
            Assert.NotNull(tuples);
            Assert.AreEqual(100, tuples.Length);

            length = 10;
            tuples = Randomizer.NextTuples(length);
            Assert.NotNull(tuples);
            Assert.AreEqual(10, tuples.Length);

            length = 5;
            tuples = Randomizer.NextTuples(length);
            Assert.NotNull(tuples);
            Assert.AreEqual(5, tuples.Length);

            length = 2;
            tuples = Randomizer.NextTuples(length);
            Assert.NotNull(tuples);
            Assert.AreEqual(2, tuples.Length);

            length = 1;
            tuples = Randomizer.NextTuples(length);
            Assert.NotNull(tuples);
            Assert.AreEqual(1, tuples.Length);

            length = 0;
            tuples = Randomizer.NextTuples(length);
            Assert.NotNull(tuples);
            Assert.AreEqual(0, tuples.Length);
        }
    }
}
