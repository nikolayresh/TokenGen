using System;

namespace TokenGen.Generator
{
    [Flags]
    public enum TokenParts : byte
    {
        Prefix,

        Body,

        Postfix
    }
}