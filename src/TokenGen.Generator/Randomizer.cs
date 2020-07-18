using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace TokenGen.Generator
{
    internal static class Randomizer
    {
        /// <summary>
        /// Selects a random character from specified string
        /// </summary>
        internal static char SelectRandomChar(string str)
        {
            var bytes = NextBytes(sizeof(int));
            var randomInt = BitConverter.ToInt32(bytes, 0) & 0x7FFFFFFF;

            return str[randomInt % str.Length];
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
    }
}