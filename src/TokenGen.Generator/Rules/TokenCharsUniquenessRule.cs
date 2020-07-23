using System.Collections.Generic;

namespace TokenGen.Generator.Rules
{
    /// <summary>
    /// Rule that ensures uniqueness of token chars
    /// </summary>
    internal class TokenCharsUniquenessRule : BaseTokenRule
    {
        internal TokenCharsUniquenessRule(TokenOptions options) : base(options)
        {
        }

        public override bool TryPass(string token)
        {
            var chars = new HashSet<char>(token.ToCharArray());


            return chars.Count >= Options.RequiredUniqueness;
        }
    }
}