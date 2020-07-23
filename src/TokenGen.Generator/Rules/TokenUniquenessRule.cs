using System.Collections.Generic;

namespace TokenGen.Generator.Rules
{
    /// <summary>
    /// Rule that ensures uniqueness of token chars
    /// </summary>
    internal class TokenUniquenessRule : BaseTokenRule
    {
        internal TokenUniquenessRule(TokenOptions options) : base(options)
        {
        }

        public override bool TryPass(string token)
        {
            var chars = new HashSet<char>(token.ToCharArray());
            var unique = Options.AllCharsUnique
                ? Options.TokenLength
                : Options.UniqueCharsRequested;

            return chars.Count >= unique;
        }
    }
}