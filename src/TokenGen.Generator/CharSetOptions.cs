using System;

namespace TokenGen.Generator
{
    /// <summary>
    /// Options used to select character sets for a token
    /// </summary>
    [Flags]
    internal enum CharSetOptions
    {
        /// <summary>
        /// No char sets at all
        /// </summary>
        None = 0x00,

        /// <summary>
        /// Character set of digits
        /// </summary>
        Digits = 0x01,

        /// <summary>
        /// Character set of lower-case English letters
        /// </summary>
        LowerCaseLetters = 0x02,

        /// <summary>
        /// Character set of upper-case English letters
        /// </summary>
        UpperCaseLetters = 0x04
    }
}