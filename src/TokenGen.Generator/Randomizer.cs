using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace TokenGen.Generator
{
    internal static class Randomizer
    {
        internal static byte[] NextBytes(int length)
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