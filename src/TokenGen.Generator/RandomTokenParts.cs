using System;

namespace TokenGen.Generator
{
    [Flags]
    public enum RandomTokenParts : byte
    {
        Prefix = 0x01,

        Payload = 0x02,

        Postfix = 0x04
    }
}