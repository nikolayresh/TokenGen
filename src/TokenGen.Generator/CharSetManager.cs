using System.Collections.Generic;
using System.Collections.Immutable;

namespace TokenGen.Generator
{
    internal static class CharSetManager
    {
        private static readonly ImmutableArray<char> Digits = "0123456789".ToCharArray().ToImmutableArray();
        private static readonly ImmutableArray<char> LowerLetters = "abcdefghijklmnopqrstuvwxyz".ToCharArray().ToImmutableArray();
        private static readonly ImmutableArray<char> UpperLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray().ToImmutableArray();

        /// <summary>
        /// Builds a joined read-only list of char sets specified by options
        /// </summary>
        internal static ImmutableList<ImmutableArray<char>> BuildCharSets(CharSetOptions sets)
        {
            var charSets = new List<ImmutableArray<char>>();

            if ((sets & CharSetOptions.Digits) != 0)
            {
                charSets.Add(Digits);
            }

            if ((sets & CharSetOptions.LowerCaseLetters) != 0)
            {
                charSets.Add(LowerLetters);
            }

            if ((sets & CharSetOptions.UpperCaseLetters) != 0)
            {
                charSets.Add(UpperLetters);
            }

            return charSets.ToImmutableList();
        }

        internal static int GetSetsCount(CharSetOptions sets)
        {
            var count = 0;

            if ((sets & CharSetOptions.Digits) != 0)
            {
                count++;
            }

            if ((sets & CharSetOptions.LowerCaseLetters) != 0)
            {
                count++;
            }

            if ((sets & CharSetOptions.UpperCaseLetters) != 0)
            {
                count++;
            }

            return count;
        }

        /// <summary>
        /// Returns a boolean value whether string contains any digits
        /// </summary>
        internal static bool ContainsAnyDigit(string str)
        {
            var chars = new HashSet<char>(str);
            return chars.Overlaps(Digits);
        }

        internal static bool ContainsAnyLowerLetter(string str)
        {
            var chars = new HashSet<char>(str);
            return chars.Overlaps(LowerLetters);
        }

        internal static bool ContainsAnyUpperLetter(string str)
        {
            var chars = new HashSet<char>(str);
            return chars.Overlaps(UpperLetters);
        }
    }
}