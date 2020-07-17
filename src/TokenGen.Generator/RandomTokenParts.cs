using System;

namespace TokenGen.Generator
{
    [Flags]
    public enum RandomTokenParts
    {
        /// <summary>
        /// Prefix part of a generated token
        /// </summary>
        Prefix = 0x01,

        /// <summary>
        /// Payload part of a generated token
        /// </summary>
        Payload = 0x02,

        Postfix = 0x04
    }
}