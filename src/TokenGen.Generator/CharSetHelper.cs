using System.Collections.Generic;
using System.Linq;

namespace TokenGen.Generator
{
    internal static class CharSetHelper
    {
        internal static readonly char[] Digits = "0123456789".ToCharArray();
        internal static readonly char[] LowerLetters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        internal static readonly char[] UpperLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        /// <summary>
        /// Builds a joined map of token symbols
        /// </summary>
        internal static Dictionary<CharSetOptions, char[]> BuildCharsMap(CharSetOptions sets)
        {
            var map = new Dictionary<CharSetOptions, char[]>();

            if ((sets & CharSetOptions.Digits) != 0)
            {
                map[CharSetOptions.Digits] = Randomizer.Shuffle(Digits).ToArray();
            }

            if ((sets & CharSetOptions.LowerCaseLetters) != 0)
            {
                map[CharSetOptions.LowerCaseLetters] = Randomizer.Shuffle(LowerLetters).ToArray();
            }

            if ((sets & CharSetOptions.UpperCaseLetters) != 0)
            {
                map[CharSetOptions.UpperCaseLetters] = Randomizer.Shuffle(UpperLetters).ToArray();
            }

            return map;
        }

        internal static int GetFlagsCount(CharSetOptions sets)
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