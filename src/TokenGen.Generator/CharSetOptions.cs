using System;

namespace TokenGen.Generator
{
    [Flags]
    public enum CharSetOptions
    {
        Digits = 0x01,

        LowerCaseLetters = 0x02,

        UpperCaseLetters = 0x04
    }
}