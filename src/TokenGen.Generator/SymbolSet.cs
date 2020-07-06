using System;
using System.Text;

namespace TokenGen.Generator
{
    public static class SymbolSet
    {
        [Flags]
        public enum Flags
        {
            Digits = 0x01,
            LowerCaseLetters = 0x02,
            UpperCaseLetters = 0x04
        }

        public const string Digits = "0123456789";
        public const string LowerLetters = "abcdefghijklmnopqrstuvwxyz";
        public const string UpperLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

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
        ///     Builds a joined set of token symbols
        /// </summary>
        public static string GetTokenSymbols(Flags flags)
        {
            var sb = new StringBuilder();

            if (flags.HasFlag(Flags.Digits)) sb.Append(Digits);

            if (flags.HasFlag(Flags.LowerCaseLetters)) sb.Append(LowerLetters);

            if (flags.HasFlag(Flags.UpperCaseLetters)) sb.Append(UpperLetters);

            return sb.ToString();
        }
    }
}