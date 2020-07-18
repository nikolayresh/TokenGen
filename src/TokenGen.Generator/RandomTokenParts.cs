using System;

namespace TokenGen.Generator
{
    [Flags]
    public enum RandomTokenParts
    {
        /// <summary>
        /// Prefix part of a generated token (user-defined part)
        /// </summary>
        Prefix = 0x01,

        /// <summary>
        /// Payload part of a generated token (the random part)
        /// </summary>
        Payload = 0x02,

        /// <summary>
        /// Postfix part of a generated token (user-defined part)
        /// </summary>
        Postfix = 0x04
    }
}