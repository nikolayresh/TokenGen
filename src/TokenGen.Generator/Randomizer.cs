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
        /// <summary>
        /// Generates an array of two-item tuples filled with random non-negative integers 
        /// </summary>
        internal static Tuple<int,int>[] NextTuples(int length)
        {
            var tuples = new Tuple<int,int>[length];
            var leftList = new List<int>(length);
            var rightList = new List<int>(length);

            var bytes = NextBytes(2 * length * sizeof(int));
            var i = 0;

            for (; i < bytes.Length; i += sizeof(int))
            { 
                var randomInt = BitConverter.ToInt32(bytes, i) & 0x7FFFFFFF;
                var list = (i < bytes.Length / 2) ? leftList : rightList;
                list.Add(randomInt);
            }

            for (i = 0; i < length; i++)
            {
                tuples[i] = new Tuple<int, int>(leftList[i], rightList[i]);
            }

            return tuples;
        }

        internal static int[] NextIntegers(int length)
        {
            var result = new int[length];
            var bytes = NextBytes(length * sizeof(int));

            for (var i = 0; i < bytes.Length; i += sizeof(int))
            {
                var randomInt = BitConverter.ToInt32(bytes, i) & 0x7FFFFFFF;
                result[i / sizeof(int)] = randomInt;
            }

            return result;
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

        /// <summary>
        /// Generates an array of random bytes with specified length
        /// </summary>
        /// <param name="length">Length of array filled with random bytes</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static byte[] NextBytes(int length)
        {
            var result = new byte[length];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(result);
            }

            return result;
        }
    }
}