using System;
using System.Collections.Generic;

namespace TokenGen.Generator
{
    internal static class CharSet
    {
        [Flags]
        public enum Flags
        {
            Digits = 0x01,
            LowerCaseLetters = 0x02,
            UpperCaseLetters = 0x04
        }

        internal static readonly char[] Digits = "0123456789".ToCharArray();
        internal static readonly char[] LowerLetters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        internal static readonly char[] UpperLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        public static int CalculateLength(Flags flags)
        {
            var length = 0;

            if (flags.HasFlag(Flags.Digits))
            {
                length += Digits.Length;
            }

            if (flags.HasFlag(Flags.LowerCaseLetters))
            {
                length += LowerLetters.Length;
            }

            if (flags.HasFlag(Flags.UpperCaseLetters))
            {
                length += UpperLetters.Length;
            }

            return length;
        }

        /// <summary>
        /// Builds a joined set of token symbols
        /// </summary>
        internal static string GetTokenSymbols(Flags flags)
        {
            var chars = new List<char>();

            if (flags.HasFlag(Flags.Digits))
            {
                chars.AddRange(Digits);
            }

            if (flags.HasFlag(Flags.LowerCaseLetters))
            {
                chars.AddRange(LowerLetters);
            }

            if (flags.HasFlag(Flags.UpperCaseLetters))
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