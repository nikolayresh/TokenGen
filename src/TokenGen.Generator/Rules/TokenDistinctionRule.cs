using System;

namespace TokenGen.Generator.Rules
{
    /// <summary>
    /// Rule that ensures a token distinction (uniqueness of token characters)
    /// </summary>
    internal class TokenDistinctionRule : BaseTokenRule
    {
        internal TokenDistinctionRule(TokenOptions options) : base(options)
        {
        }

        public override bool TryPass(string token)
        {
            var distinctChars = CountUniqueChars(token);

            return Options.DistinctChars.All
                ? (distinctChars == Options.Length)
                : (Options.DistinctChars.Exact
                    ? distinctChars == Options.DistinctChars.Count
                    : distinctChars >= Options.DistinctChars.Count);
        }

        /// <summary>
        /// Calculates count of unique/distinct characters in a specified token 
        /// </summary>
        private static int CountUniqueChars(string token)
        {
            var chars = token.ToCharArray();
            Array.Sort(chars);

            var length = chars.Length;
            var unique = 0;

            for (var i = 0; i < length; i++)
            {
                while (i < length - 1 && chars[i] == chars[i + 1])
                {
                    i++;
                }

                unique++;
            }

            return unique;
        }
    }
}