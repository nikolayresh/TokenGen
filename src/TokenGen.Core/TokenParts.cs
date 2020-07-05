using System;

namespace TokenGen.Core
{
    [Flags]
    public enum TokenParts : byte
    {
        Prefix,

        Body,

        Postfix
    }
}