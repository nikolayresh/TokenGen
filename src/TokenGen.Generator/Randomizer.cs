using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace TokenGen.Generator
{
    internal static class Randomizer
    {
        internal static int[] NextIntegers(int length)
        {
            var result = new int[length];
            var bytes = new byte[length * sizeof(int)];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(bytes);
            }

            for (var i = 0; i < bytes.Length; i += sizeof(int))
            {
                int randomInt = BitConverter.ToInt32(bytes, i) & 0x7FFFFFFF;
                result[i / sizeof(int)] = randomInt;
            }

            return result;
        }

        /// <summary>
        /// Generates a random non-negative integer
        /// </summary>
        internal static int NextInt()
        {
            var bytes = NextBytes(sizeof(int));
            var randomInt = BitConverter.ToInt32(bytes, 0) & 0x7FFFFFFF;

            return randomInt;
        }
        
        /// <summary>
        /// Selects a random item from specified array
        /// </summary>
        internal static T SelectRandomItem<T>(T[] arr)
        {
            return arr[NextInt() % arr.Length];
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