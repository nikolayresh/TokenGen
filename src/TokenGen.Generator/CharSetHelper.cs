using System.Collections.Generic;

namespace TokenGen.Generator
{
    internal static class CharSetHelper
    {
        internal static readonly char[] Digits = "0123456789".ToCharArray();
        internal static readonly char[] LowerLetters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        internal static readonly char[] UpperLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        /// <summary>
        /// Builds a joined set of token symbols
        /// </summary>
        internal static string GetTokenChars(CharSetOptions sets)
        {
            var chars = new List<char>();

            if ((sets & CharSetOptions.Digits) != 0)
            {
                chars.AddRange(Digits);
            }

            if ((sets & CharSetOptions.LowerCaseLetters) != 0)
            {
                chars.AddRange(LowerLetters);
            }

            if ((sets & CharSetOptions.UpperCaseLetters) != 0)
            {
                chars.AddRange(UpperLetters);
            }

            return string.Join(null, Randomizer.Shuffle(chars));
        }

        /// <summary>
        /// Returns a boolean value whether string contains any digits
        /// </summary>
        internal static bool ContainsDigits(string str)
        {
            var chars = new HashSet<char>(str);
            return chars.Overlaps(Digits);
        }

        internal static bool ContainsLowerLetters(string str)
        {
            var chars = new HashSet<char>(str);
            return chars.Overlaps(LowerLetters);
        }

        internal static bool ContainsUpperLetters(string str)
        {
            var chars = new HashSet<char>(str);
            return chars.Overlaps(UpperLetters);
        }
    }
}