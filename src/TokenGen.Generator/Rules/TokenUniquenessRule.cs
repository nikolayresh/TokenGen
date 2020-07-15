using System;

namespace TokenGen.Generator.Rules
{
    /// <summary>
    /// Rule that ensures uniqueness of token symbols 
    /// </summary>
    internal class TokenUniquenessRule : BaseTokenRule
    {
        internal TokenUniquenessRule(TokenOptions options) : base(options)
        {
        }

        public override bool TryPass(string token)
        {
            var chars = token.ToCharArray();
            Array.Sort(chars);

            var previous = (char) 0;
            var unique = 0;

            for (var i = 0; i < chars.Length; i++)
            {
                var current = chars[i];

                if (current != previous)
                {
                    unique++;
                }

                previous = current;
            }

            return unique >= Options.UniqueChars;
        }
    }
}