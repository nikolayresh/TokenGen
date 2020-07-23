﻿namespace TokenGen.Generator.Rules
{
    internal class TokenNeverEndsWithRule : BaseTokenRule, IShuffleOnFail
    {
        public TokenNeverEndsWithRule(TokenOptions options) : base(options)
        {
        }

        public override bool TryPass(string token)
        {
            var lastChar = token[^1];

            return !Options.ExcludedAtEnd.Contains(lastChar);
        }
    }
}
