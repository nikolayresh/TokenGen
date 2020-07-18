using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace TokenGen.Generator
{
    internal static class Randomizer
    {
        /// <summary>
        /// Generates list of random non-negative integers
        /// </summary>
        internal static List<int> NextIntegers(int length)
        {
            var result = new List<int>(length);
            var bytes = NextBytes(length * sizeof(int));

            for (var i = 0; i < bytes.Length; i += sizeof(int))
            {
                result.Add(BitConverter.ToInt32(bytes, i) & 0x7FFFFFFF);
            }

            return result;
        }

        private static byte[] NextBytes(int length)
        {
            var result = new byte[length];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(result);
            }

            return result;
        }

        internal static IEnumerable<T> Shuffle<T>(this IEnumerable<T> collection)
        {
            return 
                (from item in collection
                 orderby Guid.NewGuid()
                 select item);
        }
    }
}