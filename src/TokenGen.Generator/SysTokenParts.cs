using System;

namespace TokenGen.Generator
{
    [Flags]
    internal enum SysTokenParts
    {
        None = 0x00,

        Prefix = 0x01,

        PrefixSeparator = 0x02,

        Payload = 0x04,

        PostfixSeparator = 0x08,

        Postfix = 0x10
    }
}