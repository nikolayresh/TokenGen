using System.Security.Cryptography;

namespace TokenGen.Generator
{
    internal static class RngEngine
    {
        /// <summary>
        ///     Generates random bytes of specified length
        /// </summary>
        internal static byte[] NextBytes(int length)
        {
            var bytes = new byte[length];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(bytes);
            }

            return bytes;
        }
    }
}