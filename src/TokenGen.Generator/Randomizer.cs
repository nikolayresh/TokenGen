using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

[assembly: InternalsVisibleTo("TokenGen.Tests")]
namespace TokenGen.Generator
{
    internal static class Randomizer
    {
        private static readonly Tuple<int, int>[] EmptyTuples = {};

        /// <summary>
        /// Generates an array of two-item tuples filled with random non-negative integers 
        /// </summary>
        internal static Tuple<int,int>[] NextTuples(int length)
        {
            if (length == 0)
            {
                return EmptyTuples;
            }

            var tuples = new Tuple<int,int>[length];
            var listOne = new List<int>(length);
            var listTwo = new List<int>(length);

            var bytes = NextBytes(2 * length * sizeof(int));
            var i = 0;

            for (; i < bytes.Length; i += sizeof(int))
            { 
                var randomInt = BitConverter.ToInt32(bytes, i) & 0x7FFFFFFF;
                var list = (i < bytes.Length / 2) ? listOne : listTwo;
                list.Add(randomInt);
            }

            for (i = 0; i < length; i++)
            {
                tuples[i] = new Tuple<int, int>(listOne[i], listTwo[i]);
            }

            return tuples;
        }

        internal static T SelectRandomItem<T>(T[] items)
        {
            return items[NextInt() % items.Length];
        }

        internal static IEnumerable<T> Shuffle<T>(IEnumerable<T> collection)
        {
            return 
                (from item in collection
                 orderby Guid.NewGuid()
                 select item);
        }

        internal static string Shuffle(string str)
        {
            return string.Join(null, Shuffle((IEnumerable<char>) str));
        }

        private static int NextInt()
        {
            var bytes = NextBytes(sizeof(int));
            int randomInt = BitConverter.ToInt32(bytes, 0) & 0x7FFFFFFF;

            return randomInt;
        }

        /// <summary>
        /// Generates an array of random bytes with specified length
        /// </summary>
        /// <param name="length">Length of array filled with random bytes</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static byte[] NextBytes(int length)
        {
            var retResult = new byte[length];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(retResult);
            }

            return retResult;
        }
    }
}